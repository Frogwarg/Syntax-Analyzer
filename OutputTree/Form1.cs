using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace OutputTree
{
    public partial class Form1 : Form
    {
        List<string> inputExprText = new List<string>();
        List<Expres> expresList = new List<Expres>();
        string inputText = "";
        int counterExpr = 0;
        Dictionary<string, string> symbols = new Dictionary<string, string>();
        public Form1()
        {
            InitializeComponent();
            Expres.textbox = textTxt;
            Expres.errorbox = errorsTxt;
        }
        public bool getText()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Текстовые файлы|*.txt";
            openFileDialog.Title = "Выберите текстовый файл";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    inputText = File.ReadAllText(openFileDialog.FileName, Encoding.GetEncoding(1251));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(string.Format("Ошибка при загрузке файла: {0}", ex.Message));
                }
            }
            else
            {
                MessageBox.Show("Неизвестная ошибка", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private void loadBtn_Click(object sender, EventArgs e)
        {
            counterExpr = 0;
            prevExprBtn.Enabled = false;
            nextExprBtn.Enabled = false;
            expressionTxt.Text = "";
            textTxt.Text = "";
            errorsTxt.Text = "";
            outTxt.Text = "";
            leksemsTable.Rows.Clear();
            if (!getText())
                return;
            if (inputText.Length == 0)
            {
                MessageBox.Show("Файл пуст");
                return;
            }
            textTxt.Text = inputText;
            FindExpressions();
            if (inputExprText.Count > 1)
            {
                nextExprBtn.Enabled = true;
            }
            if (inputExprText.Count == 0)
            {
                errorsTxt.Text += "Ошибка: Ожидался разделитель выражений (;)" + Environment.NewLine;
                return;
            }
            string expr = inputExprText[counterExpr];
            expressionTxt.Text = expr;
            Expres.fullText = textTxt.Text;
            Expres.countn = new Regex(@"\n").Matches(textTxt.Text).Count;
            makeExpress();
            outTable();
        }
        public void FindExpressions()
        {
            inputExprText.Clear();
            Regex pattern = new Regex(@"(/\*([^*]|[\r\n]|(\*+([^*/]|[\r\n])))*\*+/)|(//.*)", RegexOptions.Singleline);
            foreach (Match str in pattern.Matches(inputText))
            {
                inputText = inputText.Replace(str.Value, "");
            }
            pattern = new Regex(".*?;", RegexOptions.Singleline);
            foreach (Match str in pattern.Matches(inputText))
            {
                string m = str.Value.Replace(Environment.NewLine, "");
                inputExprText.Add(m);
            }
        }
        public void makeExpress()
        {
            expresList.Clear();
            FindExpressions();
            if (String.IsNullOrEmpty(inputText) || String.IsNullOrWhiteSpace(inputText))
            {
                MessageBox.Show("Исходный текст пуст");
                return;
            }
            Expres expres;
            foreach (string express in inputExprText)
            {
                expres = new Expres(express);
                expresList.Add(expres);
            }
            expresList[counterExpr].leksOut(leksemsTable);
            if (!String.IsNullOrEmpty(errorsTxt.Text))
            {
                return;
            }
            errorsTxt.Text += "Ошибок не обнаружено" + Environment.NewLine;
            grammarTxt.Text += Grammar.OutRules();
            foreach(Expres express in expresList)
            {
                express.DoGrammar(outTxt, pictureBox1);
            }
            outGrammatics();
        }
        public void outGrammatics()
        {
            outTxt.Text = "Строка преобразована:\n" + expresList[counterExpr].inputString;
            if (expresList[counterExpr].outputString != "")
            {
                outTxt.Text += Environment.NewLine + "Строка принята:\n" + expresList[counterExpr].outputString;
                outTxt.Text += "\n=> " + expresList[counterExpr].exp;

                // Создаем новый Bitmap для рисунка
                Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                // Создаем Graphics из Bitmap
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    // Отрисовываем дерево на Graphics
                    DrawTree(expresList[counterExpr].tree, pictureBox1.Width / 2 + pictureBox1.Width / 4 - pictureBox1.Width / 8, 50, 50, 50, 50, g);
                }
                // Устанавливаем Bitmap в качестве изображения PictureBox
                pictureBox1.Image = bmp;
                outTxt.Text +="\nПроверка:\n"+ expresList[counterExpr].tree.LeftmostLeafTraversal();
            }
            else
            {
                outTxt.Text += Environment.NewLine + "Строка не принята";
                // Очищаем PictureBox
                pictureBox1.Image = null;
            }
        }
        private void prevExprBtn_Click(object sender, EventArgs e)
        {
            if (inputExprText.Count == 0 || String.IsNullOrEmpty(inputExprText[counterExpr - 1]))
            {
                MessageBox.Show("Выражений нет");
                return;
            }
            counterExpr--;
            expressionTxt.Text = inputExprText[counterExpr];
            outGrammatics();
            if (counterExpr - 1 < 0)
            {
                prevExprBtn.Enabled = false;
            }
            nextExprBtn.Enabled = true;
            expresList[counterExpr].leksOut(leksemsTable);
        }

        private void nextExprBtn_Click(object sender, EventArgs e)
        {
            if (inputExprText.Count == 0 || String.IsNullOrEmpty(inputExprText[counterExpr + 1]))
            {
                MessageBox.Show("Выражений нет");
                return;
            }
            counterExpr++;
            expressionTxt.Text = inputExprText[counterExpr];
            outTxt.Text = "Строка преобразована:\n" + expresList[counterExpr].inputString;
            outGrammatics();
            if (counterExpr + 2 > inputExprText.Count)
            {
                nextExprBtn.Enabled = false;
            }
            prevExprBtn.Enabled = true;
            expresList[counterExpr].leksOut(leksemsTable);
        }
        public void outTable()
        {
            mergeTables();
            using (StreamWriter writer = new StreamWriter("../../TableOutput/identifierTable.txt"))
            {
                double result;
                foreach (KeyValuePair<string, string> pair in symbols)
                {
                    double.TryParse(pair.Key, out result);
                    writer.WriteLine("{0,-32} - {1,-32} - {2}", pair.Key, pair.Value, result);
                }
            }
        }
        public void mergeTables()
        {
            foreach (Expres expr in expresList)
            {
                foreach (KeyValuePair<string, string> dict in expr.leksems)
                {
                    if (!symbols.ContainsKey(dict.Key))
                    {
                        symbols.Add(dict.Key, dict.Value);
                    }
                }
            }
        }
        void DrawTree(TreeNode<string> node, int x, int y, int xOffset, int yOffset, int yDistance, Graphics g)
        {
            DrawEdges(node, x, y, xOffset, yOffset, yDistance, g);
            DrawNodes(node, x, y, xOffset, yOffset, yDistance, g);
        }
        private void DrawEdges(TreeNode<string> node, int x, int y, int xOffset, int yOffset, int yDistance, Graphics g = null)
        {
            if (g == null)
                g = pictureBox1.CreateGraphics();

            int radius = 10; // Изменим размер вершин, сделаем их чуть больше.
            int childrenCount = node.Children.Count;
            if (childrenCount > 0)
            {
                int startX = x - (xOffset * (childrenCount - 1)) / 2; // немного изменим формулу для четкого распределения линий
                for (int i = 0; i < childrenCount; i++)
                {
                    int childX = startX + i * xOffset;
                    int childY = y + yDistance;

                    using (Pen thickPen = new Pen(Color.Red, 3)) // Теперь линии будут фиолетовые и толще
                    {
                        g.DrawLine(thickPen, x, y + radius, childX, childY - radius); // Отступаем вниз от верхней части круга
                    }

                    DrawEdges(node.Children[i], childX, childY, xOffset, yOffset, yDistance, g);
                }
            }
        }

        private void DrawNodes(TreeNode<string> node, int x, int y, int xOffset, int yOffset, int yDistance, Graphics g = null)
        {
            if (g == null)
                g = pictureBox1.CreateGraphics();

            int radius = 20; // Это регулирует размер узлов дерева.
            Brush fillBrush = Brushes.Blue; // Кисть для внутреннего цвета
            Pen borderPen = new Pen(pictureBox1.BackColor /*Color.Black*/, 2); // Ручка для обводки

            // Отрисовка круга для узла
            g.FillEllipse(fillBrush, x - radius, y - radius, 2 * radius, 2 * radius);
            g.DrawEllipse(borderPen, x - radius, y - radius, 2 * radius, 2 * radius); // Отрисовка обводки

            Font nodeFont = new Font("Tahoma", 10, FontStyle.Bold); // Выберем шрифт понятнее и жирнее
            Brush textBrush = Brushes.White; // Изменим цвет текста на белый для контраста

            string nodeText = node.Data.ToString();
            SizeF textSize = g.MeasureString(nodeText, nodeFont);
            float textX = x - (textSize.Width / 2);
            float textY = y - (textSize.Height / 2);
            g.DrawString(nodeText, nodeFont, textBrush, textX, textY);

            // Рекурсивный вызов для отрисовки дочерних узлов
            int childrenCount = node.Children.Count;
            if (childrenCount > 0)
            {
                int startX = x - (xOffset * (childrenCount - 1)) / 2;
                for (int i = 0; i < childrenCount; i++)
                {
                    int childX = startX + i * xOffset;
                    int childY = y + yDistance;

                    DrawNodes(node.Children[i], childX, childY, xOffset, yOffset, yDistance, g);
                }
            }
        }
        private void inputStringTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
