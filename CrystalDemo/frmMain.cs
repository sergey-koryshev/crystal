using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Crystal
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            Program.settings = new Settings();
            //AddingPage c = new AddingPage();
            //c.ShowDialog();
        }

        private void treeProject_AfterSelect(object sender, TreeViewEventArgs e)
        {
            txtOriginal.Clear();
            txtNew.Clear();
            StringBuilder originalText;
            StringBuilder newText;
            switch (treeProject.SelectedNode.Tag)
            {
                case "Paragraph":
                    originalText = new StringBuilder(Regex.Replace(Program.book.ExportOriginalText(treeProject.SelectedNode.Parent.Index, treeProject.SelectedNode.Index), @"[\s-[\r\n]]", "·"));

                    txtOriginal.Text = originalText.ToString();

                    newText = new StringBuilder(Regex.Replace(Program.book.ExportNewText(treeProject.SelectedNode.Parent.Index, treeProject.SelectedNode.Index), @"[\s-[\r\n]]", "·"));

                    txtNew.Text = newText.ToString();

                    propertyGrid1.SelectedObject = Program.book.pages[treeProject.SelectedNode.Parent.Index].paragraphs[treeProject.SelectedNode.Index];
                    break;
                case "Page":
                    propertyGrid1.SelectedObject = Program.book.pages[treeProject.SelectedNode.Index];

                    StringBuilder text = new StringBuilder();

                    foreach (Paragraph paragraph in Program.book.pages[treeProject.SelectedNode.Index].paragraphs)
                    {
                        text.Append(paragraph.NewText);
                    }

                    Analize(Regex.Replace(text.ToString(), "[[{].*[}]]|[\r\n]", ""));

                    break;
                case "Book":
                    propertyGrid1.SelectedObject = Program.book;
                    break;
                default:
                    break;
            }

        }

        public int AmountLetters(string _text)
        {
            int result = 0;
            int i = 0;
            StringBuilder text = new StringBuilder(Regex.Replace(_text, @"\r\n", ""));

            while (i < text.Length)
            {
                switch(text[i])
                {
                    case '[':
                        result++;
                        i++;
                        int j = i;
                        while ((j < text.Length) && (text[j] != ']'))
                        {
                            j++;
                        }
                        j++;
                        i = j;
                        break;
                    case '{':
                        result++;
                        i++;
                        int k = i;
                        while ((k < text.Length) && (text[k] != '}'))
                        {
                            k++;
                        }
                        k++;
                        i = k;
                        break;
                    default:
                        result++;
                        i++;
                        break;
                }
            }
            return result;
        }


        private void btnImport_Click(object sender, EventArgs e)
        {
            StringBuilder text = new StringBuilder(Regex.Replace(txtNew.Text, @"·", " "));

            Program.book.ImportText(treeProject.SelectedNode.Parent.Index, treeProject.SelectedNode.Index, text.ToString());
        }

        private void txtOriginal_TextChanging(object sender, FastColoredTextBoxNS.TextChangingEventArgs e)
        {
            if (e.InsertingText == " ")
            {
                e.InsertingText = "·";
            }
        }

        private void txtNew_TextChanging(object sender, FastColoredTextBoxNS.TextChangingEventArgs e)
        {
            if (e.InsertingText == " ")
            {
                e.InsertingText = "·";
            }
        }

        private void txtOriginal_SelectionChanged(object sender, EventArgs e)
        {
            txtLength.Text = AmountLetters(txtOriginal.SelectedText).ToString();
        }

        private void txtNew_SelectionChanged(object sender, EventArgs e)
        {
            txtLength.Text = AmountLetters(txtNew.SelectedText).ToString();
        }

        private void txtNew_TextChanged(object sender, FastColoredTextBoxNS.TextChangedEventArgs e)
        {
            
            Analize(Regex.Replace(Regex.Replace(txtNew.Text, "·", " "), "[[{].*[}]]|[\r\n]", ""));
        }

        private void Analize(string _text)
        {
            txtTextAnalizerAmount.Clear();
            txtTextAnalizerCollection.Clear();

            FrequencyAnalysis fa = new FrequencyAnalysis(_text);

            fa.Analise();

            txtTextAnalizerAmount.Text = fa.Count.ToString();

            foreach (var c in fa)
            {

                if (c.Key == ' ')
                {
                    txtTextAnalizerCollection.AppendText(string.Format("space({0}) ", c.Value));
                }
                else
                {
                    txtTextAnalizerCollection.AppendText(string.Format("{0}({1}) ", c.Key, c.Value));
                }
            }
        }

        private void propertyGrid1_Click(object sender, EventArgs e)
        {

        }

        private void btnSaveNewText_Click(object sender, EventArgs e)
        {
            StringBuilder text = new StringBuilder(Regex.Replace(txtNew.Text, @"·", " "));

            Program.book.SetNewText(treeProject.SelectedNode.Parent.Index, treeProject.SelectedNode.Index, text.ToString());

        }

        private void openProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openProject.ShowDialog();

            if(openProject.FileName != "")
            {
                Program.settings.ProjectPath = openProject.FileName;
                Project.OpenProject(Program.settings.ProjectPath);
                UpdateTree();
            }
        }

        private void UpdateTree()
        {
            treeProject.Nodes.Clear();

            TreeNode addingBook = new TreeNode(Program.book.Name);
            addingBook.Tag = "Book";
            treeProject.Nodes.Add(addingBook);

            foreach (Page page in Program.book.pages)
            {
                TreeNode addingPage = new TreeNode(page.Name);
                addingPage.Tag = "Page";
                addingBook.Nodes.Add(addingPage);
                foreach (Paragraph paragraph in page.paragraphs)
                {
                    TreeNode addingParagraph = new TreeNode(paragraph.Name);
                    addingParagraph.Tag = "Paragraph";
                    addingPage.Nodes.Add(addingParagraph);
                }
            }
        }

        private void btnRevertNewText_Click(object sender, EventArgs e)
        {
            Program.book.RevertNewText(treeProject.SelectedNode.Parent.Index, treeProject.SelectedNode.Index);

            StringBuilder newText = new StringBuilder(Regex.Replace(Program.book.ExportNewText(treeProject.SelectedNode.Parent.Index, treeProject.SelectedNode.Index), @"[\s-[\r\n]]", "·"));

            txtNew.Text = newText.ToString();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveProject.ShowDialog();

            if (saveProject.FileName != null)
            {
                Project.SaveProject(saveProject.FileName);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.settings.ProjectPath != "")
            {
                Project.SaveProject(Program.settings.ProjectPath);
            }
        }

        private void exportScriptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveScript.ShowDialog();

            if (saveScript.FileName != "")
            {
                using (StreamWriter file = new StreamWriter(saveScript.FileName, false, System.Text.Encoding.UTF8))
                {
                    foreach (Page page in Program.book.pages)
                    {
                        foreach (Paragraph paragraph in page.paragraphs)
                        {
                            file.WriteLine(String.Format("@{0}", paragraph.Name));
                            file.WriteLine(paragraph.NewText);
                            file.WriteLine("@");
                            file.WriteLine();
                        }
                    }
                }
            }
        }

        private void contextMenuProjectTree_Opening(object sender, CancelEventArgs e)
        {
            if (treeProject.SelectedNode != null)
            {
                switch (treeProject.SelectedNode.Tag.ToString())
                {
                    case "Book":
                        contextMenuProjectTree.Items[0].Enabled = true;
                        contextMenuProjectTree.Items[1].Enabled = false;
                        contextMenuProjectTree.Items[2].Enabled = true;
                        break;
                    case "Page":
                        contextMenuProjectTree.Items[0].Enabled = false;
                        contextMenuProjectTree.Items[1].Enabled = true;
                        contextMenuProjectTree.Items[2].Enabled = true;
                        break;
                    case "Paragraph":
                        contextMenuProjectTree.Items[0].Enabled = false;
                        contextMenuProjectTree.Items[1].Enabled = false;
                        contextMenuProjectTree.Items[2].Enabled = true;
                        break;
                }
            } else
            {
                contextMenuProjectTree.Items[0].Enabled = false;
                contextMenuProjectTree.Items[1].Enabled = false;
                contextMenuProjectTree.Items[2].Enabled = false;
            }
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (AddingPage addPageFrom = new AddingPage(treeProject.SelectedNode.Index))
            {
                addPageFrom.ShowDialog();
            }
            UpdateTree();
        }
    }
}
