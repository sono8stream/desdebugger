using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace desdebugger
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        [DllImport("arm-disasm.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern void Disasm(uint adr, uint ins, System.Text.StringBuilder str);
        [DllImport("arm-disasm.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern void DisasmThumb(uint adr, uint ins, System.Text.StringBuilder str);

        private System.Net.Sockets.TcpClient client;
        private uint memoryAdr;
        private uint[] registers;
        private AutoCompleteStringCollection addressCollection;

        private Process emulatorProcess;

        private bool isContinue = false;
        private bool onKillProcess = false;

        private void Form1_Load(object sender, EventArgs e)
        {
            textBoxBp.AutoCompleteCustomSource = addressCollection;
            textBoxGoto.AutoCompleteCustomSource = addressCollection;
            addressCollection = new AutoCompleteStringCollection();
            if (Properties.Settings.Default.Addresses != null)
            {
                foreach (string s in Properties.Settings.Default.Addresses)
                {
                    addressCollection.Add(s);
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Addresses = new System.Collections.Specialized.StringCollection();
            int i = 0;
            foreach (string s in addressCollection)
            {
                Properties.Settings.Default.Addresses.Add(s);
                i++;
                if (i >= 10)
                {
                    break;
                }
            }
            Properties.Settings.Default.Save();

            if (isContinue)
            {
                onKillProcess = true;
                Stop();
            }

            if (emulatorProcess != null)
            {
                emulatorProcess.Kill();
            }
        }

        private void buttonLaunch_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog()
            {
                Filter = "Exe file (*.exe)|*.exe",
                Title = "Open DeSmuME (only dev+ edition is supported)"
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string filePath = dialog.FileName;
                    emulatorProcess = Process.Start(filePath, "--arm9gdb " + GetPortNumber());
                    client = new System.Net.Sockets.TcpClient("localhost", GetPortNumber());
                    UpdateRegisters();
                    Goto(0x02000000);
                    RunEmulator();
                    statusLabel.Text = "Connected to DeSmuME";
                }
                catch (Exception ex)
                {
                    statusLabel.Text = ex.Message;
                }
            }
            dialog.Dispose();
        }

        private int GetPortNumber()
        {
            return Convert.ToInt32(textBoxPort.Text);
        }

        private int DISASM_LEN = 30;

        private void UpdateDisasm()
        {
            if (client == null) return;
            bool thumb = radioButtonThumb.Checked;
            if (listBoxDisasm.Items.Count != DISASM_LEN)
            {
                listBoxDisasm.Items.Clear();
                for (var i = 0; i < DISASM_LEN; i++)
                {
                    listBoxDisasm.Items.Add("");
                }
            }
            for (var i = 0; i < DISASM_LEN; i++)
            {
                var adr = (uint)(memoryAdr + i * (thumb ? 2 : 4));
                listBoxDisasm.Items[i] = CreateDisasmText(thumb, adr);
            }
            UpdateScroolbarValue();
        }

        private string CreateDisasmText(bool thumb, uint adr)
        {
            var buf = new StringBuilder(256);
            var ins = thumb ? GetMemory16(adr, 1)[0] : GetMemory32(adr, 1)[0];
            if (thumb)
            {
                DisasmThumb(adr, ins, buf);
            }
            else
            {
                Disasm(adr, ins, buf);
            }

            string str = "";
            if (registers[15] == adr)
            {
                str += "> ";
            }
            str += $"{adr:X8} {(thumb ? ins.ToString("X4") : ins.ToString("X8"))} " + buf.ToString().ToLower();

            var match = System.Text.RegularExpressions.Regex.Match(str, @"\[pc, #([0-9a-f]+)\]");
            if (match.Success)
            {
                var ofs = Convert.ToInt32(match.Groups[1].Value, 16);
                if (thumb)
                {
                    str = str.Substring(0, match.Index) + String.Format("#{0:X8}", GetMemory32((uint)(((adr + 4) & ~3) + ofs), 1)[0]);
                }
            }
            return str;
        }

        private void Goto(uint adr)
        {
            bool thumb = radioButtonThumb.Checked;
            if (memoryAdr <= adr && adr < memoryAdr + DISASM_LEN * (thumb ? 2 : 4))
            {
            }
            else
            {
                memoryAdr = adr;
            }
            UpdateDisasm();
            listBoxDisasm.SelectedIndex = (int)(adr - memoryAdr) / (thumb ? 2 : 4);
        }

        private void UpdateRegisters()
        {
            var reg = GetRegisters();
            registers = reg;
            listViewReg.Items.Clear();
            for (var i = 0; i < reg.Length; i++)
            {
                string[] strings = { String.Format("{0:x8}", reg[i]), Convert.ToString(i) };
                var item = new ListViewItem(strings);
                listViewReg.Items.Add(item);
            }
        }

        private uint[] GetMemory16(uint adr, int size)
        {
            var memory = new List<uint>();

            for (int i = 0; i < size; i++)
            {
                var res = Interact(String.Format("m{0:x8},{1:X}", adr + i * 2, 2));
                if (res[0] == 'E')
                {
                    memory.Add(0);
                }
                else
                {
                    memory.Add(Convert.ToUInt32(res.Substring(2, 2) + res.Substring(0, 2), 16));
                }
            }
            return memory.ToArray();
        }

        private uint[] GetMemory32(uint adr, int size)
        {
            var memory = new List<uint>();

            for (int i = 0; i < size; i++)
            {
                var res = Interact(String.Format("m{0:x8},{1:X}", adr + i * 4, 4));
                if (res[0] == 'E')
                {
                    memory.Add(0);
                }
                else
                {
                    memory.Add(Convert.ToUInt32(res.Substring(6, 2) + res.Substring(4, 2) + res.Substring(2, 2) + res.Substring(0, 2), 16));
                }
            }
            return memory.ToArray();
        }

        private uint[] GetRegisters()
        {
            var registers = new List<uint>();
            string res = Interact("g");
            for (int i = 0; i < res.Length / 8; i++)
            {
                var str = res.Substring(i * 8, 8);
                registers.Add(Convert.ToUInt32(str.Substring(6, 2) + str.Substring(4, 2) + str.Substring(2, 2) + str.Substring(0, 2), 16));
            }
            return registers.ToArray();
        }

        private string Interact(string request)
        {
            //Console.WriteLine(request);
            var stream = client.GetStream();

            var bytes = Encoding.UTF8.GetBytes("$" + request + "#" + String.Format("{0:X2}", Checksum(request)));
            stream.Write(bytes, 0, bytes.Length);

            var retBytes = new List<byte>();
            int c;
            c = stream.ReadByte();
            c = stream.ReadByte();
            while ((c = stream.ReadByte()) != Convert.ToByte('#'))
            {
                retBytes.Add((byte)c);
            }
            c = stream.ReadByte();
            c = stream.ReadByte();
            stream.WriteByte(Convert.ToByte('+'));
            var response = System.Text.Encoding.UTF8.GetString(retBytes.ToArray());
            //Console.WriteLine(response);
            return response;
        }

        private void Stop()
        {
            var stream = client.GetStream();
            var bytes = Encoding.UTF8.GetBytes("$s#" + String.Format("{0:X2}", Checksum("?")));
            stream.Write(bytes, 0, bytes.Length);
            while (isContinue) { }
        }

        private int Checksum(string str)
        {
            var chars = str.ToCharArray();
            uint sum = 0;
            foreach (char c in chars)
            {
                sum += c;
            }
            return (int)(sum % 256);
        }

        private void RunEmulator()
        {
            isContinue = true;
            SwitchContinue(true);

            var progress = new Progress<bool>((done) =>
            {
                if (done)
                {
                    UpdateRegisters();
                    Goto(registers[15]);
                    statusLabel.Text = "Breaked";
                    SwitchContinue(false);
                }
            });

            Action<IProgress<bool>> work = (p) =>
            {
                Interact("c");
                isContinue = false;

                if (!onKillProcess)
                {
                    p.Report(true);
                }
            };
            Task.Run(() => work(progress));
        }

        private void buttonContinue_Click(object sender, EventArgs e)
        {
            statusLabel.Text = "Started to Trace";
            RunEmulator();
        }

        private void buttonStep_Click(object sender, EventArgs e)
        {
            Interact("s");
            UpdateRegisters();
            Goto(registers[15]);
        }

        private void buttonStepOver_Click(object sender, EventArgs e)
        {
            uint pc = GetRegisters()[15];
            bool thumb = radioButtonThumb.Checked;

            var buf = new StringBuilder(256);
            var ins = thumb ? GetMemory16(pc, 1)[0] : GetMemory32(pc, 1)[0];
            if (thumb)
            {
                DisasmThumb(pc, ins, buf);
            }
            else
            {
                Disasm(pc, ins, buf);
            }
            string insName = buf.ToString().ToLower();
            string insTypeName = insName.Split()[0];

            if (insTypeName=="bl"||insTypeName=="blx")
            {
                uint targetPC = pc + (uint)(thumb ? 2 : 4);
                do
                {
                    Interact("s");
                    pc = GetRegisters()[15];
                } while (pc != targetPC);
            }
            else
            {
                Interact("s");
            }
            UpdateRegisters();
            Goto(registers[15]);
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            Stop();
        }

        private void buttonGoto_Click(object sender, EventArgs e)
        {
            Goto(Convert.ToUInt32(textBoxGoto.Text, 16));
        }

        private void radioButtonARM_CheckedChanged(object sender, EventArgs e)
        {
            UpdateDisasm();
        }

        private void radioButtonThumb_CheckedChanged(object sender, EventArgs e)
        {
            UpdateDisasm();
        }

        private void ChangeRegister(int index, uint value)
        {
            Interact(String.Format("P{0:x}={1:x2}{2:x2}{3:x2}{4:x2}", index, value & 0xff, value >> 8 & 0xff, value >> 16 & 0xff, value >> 24 & 0xff));
        }

        private void listViewReg_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var form = new FormSetRegister();
            var item = listViewReg.SelectedItems[0];
            form.SetValue(Convert.ToUInt32(item.Text, 16));
            form.ShowDialog(this);
            var value = form.GetValue();
            form.Dispose();
            ChangeRegister(item.Index, value);
            UpdateRegisters();
        }

        private void listBoxDisasm_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void listBoxDisasm_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void listBoxDisasm_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyData == Keys.Up && listBoxDisasm.SelectedIndex == 0)
            {
                DisasmUp();
            }
            if (e.KeyData == Keys.Down && listBoxDisasm.SelectedIndex == DISASM_LEN - 1)
            {
                DisasmDown();
            }
        }

        private void DisasmUp()
        {
            var thumb = radioButtonThumb.Checked;
            memoryAdr = (uint)(memoryAdr - (thumb ? 2 : 4));
            var str = CreateDisasmText(thumb, memoryAdr);
            listBoxDisasm.Items.RemoveAt(DISASM_LEN - 1);
            listBoxDisasm.Items.Insert(0, str);
            UpdateScroolbarValue();
        }

        private void DisasmDown()
        {
            var thumb = radioButtonThumb.Checked;
            memoryAdr = (uint)(memoryAdr + (thumb ? 2 : 4));
            var adr = (uint)(memoryAdr + (DISASM_LEN - 1) * (thumb ? 2 : 4));
            var str = CreateDisasmText(thumb, adr);
            listBoxDisasm.Items.RemoveAt(0);
            listBoxDisasm.Items.Add(str);
            UpdateScroolbarValue();
        }

        const uint MEMORY_MAX = 0x08000000;

        private void UpdateScroolbarValue()
        {
            int value = (int)Math.Round((double)memoryAdr / MEMORY_MAX * vScrollBar1.Maximum);
            if (vScrollBar1.Minimum <= value && value <= vScrollBar1.Maximum)
            {
                vScrollBar1.Value = value;
            }
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.NewValue == e.OldValue)
            {
                // do nothing
            }
            else if (e.NewValue == e.OldValue - 1)
            {
                DisasmUp();
            }
            else if (e.NewValue == e.OldValue + 1)
            {
                DisasmDown();
            }
            else
            {
                memoryAdr = (uint)((double)vScrollBar1.Value / vScrollBar1.Maximum * MEMORY_MAX) & unchecked((uint)~3);
                UpdateDisasm();
            }
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            if (listBoxBp.SelectedIndex == -1)
            {
                return;
            }

            if (isContinue)
            {
                Stop();
            }

            string str = (string)listBoxBp.Items[listBoxBp.SelectedIndex];
            string condition = str.Substring(0, 7);
            uint address = Convert.ToUInt32(str.Substring(8), 16);

            switch (condition)
            {
                case "INSTR: ":
                    Interact(String.Format("z0,{0:X8},4", address));
                    break;
                case "WRITE: ":
                    Interact(String.Format("z2,{0:X8},4", address));
                    break;
                case "READ : ":
                    Interact(String.Format("z3,{0:X8},4", address));
                    break;
            }
            listBoxBp.Items.RemoveAt(listBoxBp.SelectedIndex);
        }

        private void listBoxDisasm_Resize(object sender, EventArgs e)
        {
            if (DISASM_LEN != listBoxDisasm.Height / listBoxDisasm.ItemHeight)
            {
                DISASM_LEN = listBoxDisasm.Height / listBoxDisasm.ItemHeight;
                UpdateDisasm();
            }
        }


        /*
         * BreakPoint types
         * 0,1:instr_bp
         * 2:write_bp
         * 3:read_bp
         * 4:access_bp
        */
        private void buttonInstrBp_click(object sender, EventArgs e)
        {
            uint address = Convert.ToUInt32(textBoxBp.Text, 16);
            SetBreakpoint(address, BreakType.Instruction);
        }

        private void buttonWriteBp_Click(object sender, EventArgs e)
        {
            uint address = Convert.ToUInt32(textBoxBp.Text, 16);
            SetBreakpoint(address, BreakType.Write);
        }

        private void buttonReadBp_Click(object sender, EventArgs e)
        {
            uint address = Convert.ToUInt32(textBoxBp.Text, 16);
            SetBreakpoint(address, BreakType.Read);
        }

        private void SetBreakpoint(uint address, BreakType breakType)
        {
            bool continueing = isContinue;
            if (continueing)
            {
                Stop();
            }

            switch (breakType)
            {
                case BreakType.Instruction:
                    statusLabel.Text = $"Set instruction break point at {address:X8}";
                    Interact(String.Format("Z0,{0:X8},4", address));
                    listBoxBp.Items.Add($"INSTR: {address:X8}");
                    break;
                case BreakType.Write:
                    statusLabel.Text = $"Set write break point at {address:X8}";
                    Interact(String.Format("Z2,{0:X8},4", address));
                    listBoxBp.Items.Add($"WRITE: {address:X8}");
                    break;
                case BreakType.Read:
                    statusLabel.Text = $"Set read break point at {address:X8}";
                    Interact(String.Format("Z3,{0:X8},4", address));
                    listBoxBp.Items.Add($"READ : {address:X8}");
                    break;
            }

            textBoxBp.AutoCompleteCustomSource.Add(textBoxBp.Text);
        }

        private void SwitchContinue(bool willOn)
        {
            buttonContinue.Enabled = !willOn;
            buttonStop.Enabled = willOn;
            vScrollBar1.Enabled = !willOn;
            buttonGoto.Enabled = !willOn;
        }

        private enum BreakType
        {
            Instruction = 0, Write, Read
        }

        private void listBoxDisasm_DoubleClick(object sender, EventArgs e)
        {
            int selectedIndex = listBoxDisasm.SelectedIndex;
            if (selectedIndex == -1)
            {
                return;
            }

            string row = (string)listBoxDisasm.Items[selectedIndex];
            bool thumb = radioButtonThumb.Checked;
            uint addr = (uint)(memoryAdr + selectedIndex * (thumb ? 2 : 4));
            SetBreakpoint(addr, BreakType.Instruction);
        }
    }
}
