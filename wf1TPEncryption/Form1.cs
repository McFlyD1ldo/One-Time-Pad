namespace wf1TPEncryption
{
    public partial class Form1 : Form
    {
        List<byte> input;
        List<byte> output;
        List<byte> key;
        public Form1()
        {
            InitializeComponent();
            cl1TimePad.DarkTitleBar.UseImmersiveDarkMode(this.Handle, true);            
        }

        private void btnLoadFile_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK) input = File.ReadAllBytes(openFileDialog1.FileName).ToList();

            if (openFileDialog1.ShowDialog() == DialogResult.OK) key = File.ReadAllBytes(openFileDialog1.FileName).ToList();      
        }

        private void btnEncrypt_click(object sender, EventArgs e)
        {
            if (input == null || key == null)
            {
                MessageBox.Show("Please load a file and a key");
                return;
            }
            try
            {             
                output = new cl1TimePad.OTPEncrypter().Encrypt(input, key);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSaveFile_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK) File.WriteAllBytes(saveFileDialog1.FileName, output.ToArray());
        }
    }
}