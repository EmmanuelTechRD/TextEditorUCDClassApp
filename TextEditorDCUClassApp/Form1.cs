namespace TextEditorDCUClassApp
{
    public partial class Form1 : Form
    {
        string? archivo;
        public Form1()
        {
            InitializeComponent();
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog AbrirArchivo = new OpenFileDialog();
            AbrirArchivo.Filter = "Texto|*.txt";

            if (AbrirArchivo.ShowDialog() == DialogResult.OK)
            {
                archivo = AbrirArchivo.FileName;

                using (StreamReader sr = new StreamReader(archivo))
                {
                    richTextBox1.Text = sr.ReadToEnd();
                }
            }
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog GuardarArchivo = new SaveFileDialog();
            GuardarArchivo.Filter = "Texto|*.txt";

            if (archivo != null)
            {
                using StreamWriter sw = new StreamWriter(archivo);
                {
                    sw.Write(richTextBox1.Text);
                }
            }
            else
            {
                if (GuardarArchivo.ShowDialog() == DialogResult.OK)
                {
                    archivo = GuardarArchivo.FileName;
                    using (StreamWriter sw = new StreamWriter(GuardarArchivo.FileName))
                    {
                        sw.Write(richTextBox1.Text);
                    }
                }
            }
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            archivo = null;
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
