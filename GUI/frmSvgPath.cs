using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using SVGPath;
using SVGPath.CmdDrawer;

namespace GUI
{
    public partial class frmSvgPath : Form
    {        
        Regex pathRegexer = new Regex("d=\"(.*?)\"");
        private string[] fileNames;

        public frmSvgPath()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string svgDirectory = "./samples";
            if (Directory.Exists(svgDirectory))
            {
                fileNames = Directory.GetFiles(svgDirectory);
                lbShape.Items.Clear();
                lbShape.Items.AddRange(fileNames.Select(name => Path.GetFileNameWithoutExtension(name)).ToArray());
            }
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

        private void Preview()
        {
            try
            {
                int scale = (int)nudScale.Value;
                int @base = (int)nudBase.Value;

                List<Cmd> cmds = CmdParser.Parse(txtSVGPath.Text);
                lbParsedCmds.Items.Clear();
                lbParsedCmds.Items.AddRange(cmds.Select(i => i.ToString()).ToArray());
                // for display
                List<Cmd> processedCmds = CmdScaler.Scale(CmdConverter.ExtractToSingleAndAbsolutePositionCmds(cmds), scale);
                pbPreview.Image = CmdDrawer.Draw(processedCmds, @base * scale, @base * scale, Brushes.Black);
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
    }
}
