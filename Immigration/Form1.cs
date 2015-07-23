using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Text.RegularExpressions;
//using System.Data.OleDb;
using System.IO;

namespace Immigration
{
    public partial class Form1 : Form
    {
        string configFilePath = System.IO.Path.Combine(Application.StartupPath, "List.csv");
        string kenFilePath = System.IO.Path.Combine(Application.StartupPath, "KEN.csv");

        private DataTable _connectionList = new DataTable();
        private DataTable _connectionKEN = new DataTable();

        string _url = string.Empty;

        string _uname = string.Empty;
        string _usex = string.Empty;
        string _uage = string.Empty;
        string _ucontry = string.Empty;
        string _uaddress = string.Empty;
        string[] _uphone = new string[3];
        string _email = string.Empty;

        string _nationality = string.Empty;
        string _details = string.Empty;

        string _nickname = string.Empty;    //名称
        string _workname = string.Empty;    //働いている場所の名称
        string _workcity = string.Empty;    //働いている場所の住所（県名以降）

        DataGridViewRow drow = new DataGridViewRow();
        DataView dataSource;

        //DataSet dataset = new DataSet();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //string configFilePath = System.IO.Path.Combine(Application.StartupPath, "List.csv");
            StreamReader sr = new StreamReader(configFilePath, System.Text.Encoding.GetEncoding(932));

            this._connectionList.Columns.Add("ID");
            this._connectionList.Columns.Add("NAME");
            this._connectionList.Columns.Add("GROUP");
            this._connectionList.Columns.Add("ADDRESS");
            this._connectionList.Columns.Add("CommitID");
            this._connectionList.Columns.Add("DONE");

            while (sr.Peek() >= 0)
            {
                string line = sr.ReadLine();
                string[] vals = line.Split(',');

                DataRow row = this._connectionList.NewRow();
                row["ID"] = vals[0];
                row["NAME"] = vals[1];
                row["GROUP"] = vals[2];
                row["ADDRESS"] = vals[3];
                row["CommitID"] = vals[4];
                row["DONE"] = vals[5];
                this._connectionList.Rows.Add(row);
            }

            this._connectionList.PrimaryKey = new DataColumn[] { this._connectionList.Columns["ID"] };
            dataSource = new DataView(this._connectionList);

            this.dataGridView1.DataSource = dataSource;
            this.dataGridView1.MultiSelect = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            loadSetting();

            //郵便番号CSV格納
            StreamReader srken = new StreamReader(kenFilePath, System.Text.Encoding.GetEncoding(932));
            this._connectionKEN.Columns.Add("num");
            this._connectionKEN.Columns.Add("ken");

            while (srken.Peek() >= 0)
            {
                string lineKen = srken.ReadLine();
                string[] valsken = lineKen.Split(',');

                DataRow rowken = this._connectionKEN.NewRow();
                rowken["num"] = valsken[0];
                rowken["ken"] = valsken[1];
                this._connectionKEN.Rows.Add(rowken);
            }




            //OleDbConnection connection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Application.StartupPath + "\\; Extended Properties=\"Text;HDR=YES;FMT=Delimited\"");

            //OleDbCommand command = new OleDbCommand("SELECT * FROM [KEN.CSV]", connection);

            //dataset.Clear();    // 念のためクリア

            //OleDbDataAdapter adapter = new OleDbDataAdapter(command);
            //adapter.Fill(dataset);

            sr.Close();
            srken.Close();

        }

        private void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            this.Navigated();
        }


        private void button貼り付け_Click(object sender, EventArgs e)
        {
            try
            {
                drow = getselectedRow(dataGridView1);

                if (this.dataGridView1.CurrentRow.Cells[5].Value.ToString() != "済")
                {

                    if (drow != null)
                    {
                        _nickname = drow.Cells[1].Value.ToString();
                        _workname = drow.Cells[2].Value.ToString();
                        _workcity = drow.Cells[3].Value.ToString();
                    }




                    HtmlDocument doc1 = this.webBrowser1.Document;


                    foreach (HtmlElement textArea in doc1.GetElementsByTagName("textarea"))
                    {
                        if (textArea.Name.Equals("details"))
                        {
                            textArea.SetAttribute("value", _details);
                        }
                    }

                    foreach (HtmlElement input in doc1.GetElementsByTagName("input"))
                    {
                        if (input.Name.Equals("usrname"))
                        {
                            input.SetAttribute("value", _uname);
                        }
                        if (input.Name.Equals("age"))
                        {
                            input.SetAttribute("value", _uage);
                        }
                        if (input.Name.Equals("usrcity"))
                        {
                            input.SetAttribute("value", _uaddress);
                        }

                        if (_uphone[0] != null)
                        {
                            if (input.Name.Equals("usrtelno1"))
                            {
                                input.SetAttribute("value", _uphone[0]);
                            }
                            if (input.Name.Equals("usrtelno2"))
                            {
                                input.SetAttribute("value", _uphone[1]);
                            }
                            if (input.Name.Equals("usrtelno3"))
                            {
                                input.SetAttribute("value", _uphone[2]);
                            }
                        }


                        if (input.Name.Equals("mail"))
                        {
                            input.SetAttribute("value", _email);
                        }
                        if (input.Name.Equals("nationality"))
                        {
                            input.SetAttribute("value", _nationality);
                        }
                        if (input.Name.Equals("nickname"))
                        {
                            input.SetAttribute("value", _nickname);
                        }
                        if (input.Name.Equals("workname"))
                        {
                            input.SetAttribute("value", _workname);
                        }
                        if (input.Name.Equals("workcity"))
                        {
                            input.SetAttribute("value", _workcity);
                        }
                    }

                    HtmlElementCollection selectCollection = doc1.GetElementsByTagName("select");
                    HtmlElement select = selectCollection["mencnt"];
                    HtmlElementCollection optionCollection = select.GetElementsByTagName("option");
                    HtmlElement option1 = optionCollection[16];
                    option1.SetAttribute("selected", "true");

                    select = selectCollection["womencnt"];
                    optionCollection = select.GetElementsByTagName("option");
                    option1 = optionCollection[16];
                    option1.SetAttribute("selected", "true");

                    select = selectCollection["bustype"];
                    optionCollection = select.GetElementsByTagName("option");
                    option1 = optionCollection[15];
                    option1.SetAttribute("selected", "true");

                    setSex();
                    setken();

                    if (yuubin(_workcity) != null)
                    {
                        setWorkKen(kenmei(yuubin(_workcity)));
                    }
                    else if (kenmeiGet(_workcity) != null)
                    {
                        setWorkKen(kenmeiGet(_workcity));
                    }
                }
                else
                {
                    MessageBox.Show("すでに送信済みです。\n", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show("エラーが発生しました。\n" + e1, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private HtmlDocument setLoadAttri()
        {
            HtmlDocument doc = this.webBrowser1.Document;

            HtmlElementCollection selects = doc.GetElementsByTagName("select");
            HtmlElement select = selects["info"];

            if (select != null)
            {
                foreach (HtmlElement child in select.Children)
                {
                    if (child.InnerText == "働いている場所の情報のみ")
                    {
                        child.SetAttribute("selected", "true");
                    }
                }
            }

            select.RaiseEvent("onchange");
            return doc;
        }

        private void Navigated()
        {
            this.textBoxURL.Text = this.webBrowser1.Url.ToString();

            this.textBoxメッセージ.Visible = false;

            if (this.webBrowser1.Url.ToString().Equals(_url))
            {
                this.button貼り付け.Enabled = true;
            }
            else
            {
                this.button貼り付け.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.webBrowser1.Refresh();
        }

        private void button初期ページ_Click(object sender, EventArgs e)
        {
            this.webBrowser1.Url = new Uri(_url);
        }



        public DataGridViewRow getselectedRow(DataGridView dataGridView2)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                DataGridViewRow sourceRow = dataGridView2.SelectedRows[0];

                DataGridViewRow destinationRow = new DataGridViewRow();

                destinationRow.CreateCells(dataGridView2);

                for (int i = 0; i < sourceRow.Cells.Count; i++)
                {
                    destinationRow.Cells[i].Value = sourceRow.Cells[i].Value;
                }


                return destinationRow;
            }
            else
            {
                return null;
            }
        }

        private void Form1_Shown(object sender, EventArgs e)
        {

        }

        public void loadSetting()
        {
            _url = ConfigurationManager.AppSettings["url"];
            _uname = ConfigurationManager.AppSettings["name"];
            _usex = ConfigurationManager.AppSettings["sex"];
            _uage = ConfigurationManager.AppSettings["age"];
            _ucontry = ConfigurationManager.AppSettings["contry"];
            _uaddress = ConfigurationManager.AppSettings["address"];
            //_uphone = ConfigurationManager.AppSettings["phone"];
            _email = ConfigurationManager.AppSettings["email"];
            _nationality = ConfigurationManager.AppSettings["nationality"];
            _details = ConfigurationManager.AppSettings["details"];

            Regex r2 = new Regex(@"(?<one>\d+)-(?<two>\d+)-(?<three>\d+)", RegexOptions.IgnoreCase | RegexOptions.Singleline);

            Match m2 = r2.Match(ConfigurationManager.AppSettings["phone"].ToString());

            while (m2.Success)
            {
                _uphone[0] = m2.Result("${one}");
                _uphone[1] = m2.Result("${two}");
                _uphone[2] = m2.Result("${three}");
                m2 = m2.NextMatch();
            }


        }

        private void buttonまずここ_Click(object sender, EventArgs e)
        {
            HtmlDocument doc = setLoadAttri();
        }

        public string yuubin(string inputStr)
        {

            Regex r = new Regex(@"〒(?<ue>\d+)-(?<sita>\d+)", RegexOptions.IgnoreCase | RegexOptions.Singleline);

            Match m = r.Match(inputStr);

            while (m.Success)
            {
                //Console.WriteLine(m.Result("${ue}${sita}"));
                return m.Result("${ue}${sita}");
                m = m.NextMatch();
            }

            return null;
        }

        public string kenmei(string number)
        {
            if (number != null)
            {
                //DataRow[] dataRows = dataset.Tables["Table"].Select("yubin = '" + number + "'");

                DataRow[] dataRows = this._connectionKEN.Select("num = '" + number + "'");

                foreach (DataRow row in dataRows)
                {
                    //Console.WriteLine(row[1].ToString());
                    return row[1].ToString();
                }
            }

            return "---選択してください---";
        }

        private HtmlDocument setWorkKen(string kenname)
        {
            HtmlDocument doc = this.webBrowser1.Document;

            HtmlElementCollection selects = doc.GetElementsByTagName("select");
            HtmlElement select = selects["workpref"];

            if (select != null)
            {
                foreach (HtmlElement child in select.Children)
                {
                    if (child.InnerText == kenname)
                    {
                        child.SetAttribute("selected", "true");
                    }
                }
            }
            return doc;
        }

        private HtmlDocument setSex()
        {
            HtmlDocument doc = this.webBrowser1.Document;

            HtmlElementCollection selects = doc.GetElementsByTagName("select");
            HtmlElement select = selects["sextype"];

            if (select != null)
            {
                foreach (HtmlElement child in select.Children)
                {
                    if (child.InnerText == _usex)
                    {
                        child.SetAttribute("selected", "true");
                    }
                }
            }
            return doc;
        }

        private HtmlDocument setken()
        {
            HtmlDocument doc = this.webBrowser1.Document;

            HtmlElementCollection selects = doc.GetElementsByTagName("select");
            HtmlElement select = selects["usrpref"];

            if (select != null)
            {
                foreach (HtmlElement child in select.Children)
                {
                    if (child.InnerText == _ucontry)
                    {
                        child.SetAttribute("selected", "true");
                    }
                }
            }
            return doc;
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            string htmltxt = this.webBrowser1.Document.Body.InnerText;

            Regex r2 = new Regex(@"送信完了", RegexOptions.IgnoreCase | RegexOptions.Singleline);

            Match m2 = r2.Match(htmltxt);

            if (m2.Success)
            {

                Regex r = new Regex(@"(?<num>\d+)", RegexOptions.IgnoreCase | RegexOptions.Singleline);

                Match m = r.Match(htmltxt);

                while (m.Success)
                {
                    if (dataGridView1.CurrentRow != null)
                    {
                        this.dataGridView1.CurrentRow.Cells[4].Value = m.Result("${num}");
                        this.dataGridView1.CurrentRow.Cells[5].Value = "済";
                        this.dataGridView1.EndEdit();

                        csvSave();
                    }
                    m = m.NextMatch();

                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {

            //DataTable dtable = (DataTable)dataGridView1.DataSource;
            //DataRow darow = dtable.Rows[dataGridView1.CurrentRow.Index];

            string htmltxt = this.webBrowser1.Document.Body.InnerText;

            Regex r2 = new Regex(@"送信完了", RegexOptions.IgnoreCase | RegexOptions.Singleline);

            Match m2 = r2.Match(htmltxt);

            if (m2.Success)
            {

                Regex r = new Regex(@"(?<num>\d+)", RegexOptions.IgnoreCase | RegexOptions.Singleline);

                Match m = r.Match(htmltxt);

                while (m.Success)
                {
                    if (dataGridView1.CurrentRow != null)
                    {
                        this.dataGridView1.CurrentRow.Cells[4].Value = m.Result("${num}");
                        this.dataGridView1.CurrentRow.Cells[5].Value = "済";
                        this.dataGridView1.EndEdit();

                        //dtable.Rows[dataGridView1.CurrentRow.Index][4] = m.Result("${num}");
                        //dtable.Rows[dataGridView1.CurrentRow.Index][5] = "済";
                        //drow.Cells[4].Value = m.Result("${num}");
                        //drow.Cells[5].Value = "済";
                        //dtable.Rows[dataGridView1.CurrentRow.Index].EndEdit();
                        //drow.endedit();
                        csvSave();
                    }
                    m = m.NextMatch();

                }
            }

        }

        public void csvSave()
        {
            int rows = this.dataGridView1.RowCount - 1;
            int cols = this.dataGridView1.ColumnCount;
            int lastColIndex = cols - 1;

            StreamWriter sw = new StreamWriter(configFilePath, false, System.Text.Encoding.GetEncoding("SHIFT-JIS"));

            for (int t = 0; t < rows; t++)
            {
                for (int i = 0; i < cols; i++)
                {
                    if (this.dataGridView1.Rows[t].Cells[i].Value != null)
                    {
                        string field = this.dataGridView1.Rows[t].Cells[i].Value.ToString();
                        sw.Write(field);
                    }
                    if (lastColIndex > i)
                    {
                        sw.Write(',');
                    }
                }
                sw.Write("\r\n");
            }

            sw.Close();

        }

        public string kenmeiGet(string address)
        {
            Regex r = new Regex(@"(?<ken>.{2}[都道府県]|.{3}県)", RegexOptions.IgnoreCase | RegexOptions.Singleline);

            Match m = r.Match(address);

            while (m.Success)
            {
                //Console.WriteLine(m.Result("${ue}${sita}"));
                return m.Result("${ken}");
                m = m.NextMatch();
            }

            return "---選択してください---";
        }

    }
}
