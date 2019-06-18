using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Mmosoft.Oops;
using SVGPath;
using SVGPath.CmdDrawer;

namespace GUI
{
    public partial class frmSvgPath : Form
    {
        List<Cmd> _cmds;

        private SolidBrush br;
        private Regex pathRegexer = new Regex("d=\"(.*?)\"");
        private string[] fileNames;

        public frmSvgPath()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _cmds = new List<Cmd>();

            string svgDirectory = "./samples";
            if (Directory.Exists(svgDirectory))
            {
                fileNames = Directory.GetFiles(svgDirectory);
                lbShape.Items.Clear();
                lbShape.Items.AddRange(fileNames.Select(name => Path.GetFileNameWithoutExtension(name)).ToArray());
            }
            cbColor.SelectedIndex = 0;
        }

        private void lbShape_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] lines = File.ReadAllLines(fileNames[lbShape.SelectedIndex]);
            Match match;
            foreach (var item in lines)
            {
                if ((match = pathRegexer.Match(item)).Success)
                {
                    txtSVGPath.Text = match.Groups[1].Value;
                    break;
                }
            }
        }

        private void txtSVGPath_TextChanged(object sender, EventArgs e)
        {
            Preview();
        }

        private void cbColor_TextChanged(object sender, EventArgs e)
        {
            Preview();
        }

        private void cbColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            Preview();
        }

        private void nudBase_ValueChanged(object sender, EventArgs e)
        {
            Preview();
        }

        private void nudScale_ValueChanged(object sender, EventArgs e)
        {
            Preview();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (var saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "Bitmap|*.bitmap|PNG|*.png|JPG, JPEG|*.jpg";
                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(saveDialog.FileName))
                        File.Delete(saveDialog.FileName);
                    pbPreview.Image.Save(saveDialog.FileName);
                    MessageBox.Show(string.Format("{0} has been saved.", saveDialog.FileName));
                }
            }
        }

        private void lbParsedCmds_SelectedIndexChanged(object sender, EventArgs e)
        {
            // get all command from 0 to selected command
            var cmd = new List<Cmd>();
            for (int i = 0; i <= lbParsedCmds.SelectedIndex; i++)
                cmd.Add(_cmds[i]);
            // then draw
            DrawImage(cmd);
        }

        private void InitBrushIfNeeded()
        {
            Color c = ExColorTranslator.Get(cbColor.Text);
            if (br == null)
            {
                br = new SolidBrush(c);
            }
            else
            {
                br.Color = c;
            }
        }

        private void Preview()
        {
            try
            {
                lblError.Text = string.Empty;
                //
                int scale = (int)nudScale.Value;
                _cmds = CmdParser.Parse(txtSVGPath.Text);
                List<Cmd> processedCmds = _cmds;
                processedCmds = CmdConverter.ExtractToSingleAndAbsolutePositionCmds(processedCmds);
                processedCmds = CmdScaler.Scale(processedCmds, scale);
                // load parse command into listview
                lbParsedCmds.SelectedIndexChanged -= lbParsedCmds_SelectedIndexChanged;
                lbParsedCmds.Items.Clear();
                lbParsedCmds.Items.AddRange(
                    _cmds
                    .Select(i => i.ToString())
                    .ToArray());
                lbParsedCmds.SelectedIndexChanged += lbParsedCmds_SelectedIndexChanged;
                
                // select last events
                lbParsedCmds.SelectedIndex = lbParsedCmds.Items.Count - 1;
            }
            catch (InvalidSvgCharacterException isce)
            {
                pbPreview.Image = null;
                lblError.Text = "Error: " + isce.Message;
            }
            catch (InvalidCmdException invalidCmdEx)
            {
                pbPreview.Image = null;
                lbParsedCmds.SelectedIndex = invalidCmdEx.Index;
                lblError.Text = "Error: " + invalidCmdEx.Message;
            }
            catch (Exception ex)
            {
                lblError.Text = "Error: " + ex.Message;
            }
        }

        private void DrawImage(List<Cmd> cmd)
        {
            InitBrushIfNeeded();
            int scale = (int)nudScale.Value;
            int @base = (int)nudBase.Value;

            // process commands
            List<Cmd> processedCmds = cmd;
            processedCmds = CmdConverter.ExtractToSingleAndAbsolutePositionCmds(processedCmds);
            processedCmds = CmdScaler.Scale(processedCmds, scale);
            
            // display drawned into text box
            var cmdText = new StringBuilder();
            processedCmds.ForEach(cm => cmdText.Append(cm.ToString()));
            txtParsedCmds.Text = cmdText.ToString();
            
            // draw image into preview
            pbPreview.Image = CmdDrawer.Draw(processedCmds, @base * scale, @base * scale, br);
        }

        
    }
}
