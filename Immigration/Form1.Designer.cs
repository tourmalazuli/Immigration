namespace Immigration
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナ変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナで生成されたコード

        /// <summary>
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディタで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.buttonまずここ = new System.Windows.Forms.Button();
            this.button貼り付け = new System.Windows.Forms.Button();
            this.textBoxURL = new System.Windows.Forms.TextBox();
            this.textBoxメッセージ = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button初期ページ = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // webBrowser1
            // 
            this.webBrowser1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser1.Location = new System.Drawing.Point(12, 202);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(768, 352);
            this.webBrowser1.TabIndex = 0;
            this.webBrowser1.Url = new System.Uri("https://www.immi-moj.go.jp/immimail/datainput.php", System.UriKind.Absolute);
            this.webBrowser1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser1_DocumentCompleted);
            this.webBrowser1.Navigated += new System.Windows.Forms.WebBrowserNavigatedEventHandler(this.webBrowser1_Navigated);
            // 
            // buttonまずここ
            // 
            this.buttonまずここ.Location = new System.Drawing.Point(133, 32);
            this.buttonまずここ.Name = "buttonまずここ";
            this.buttonまずここ.Size = new System.Drawing.Size(93, 23);
            this.buttonまずここ.TabIndex = 1;
            this.buttonまずここ.Text = "まずここを押す";
            this.buttonまずここ.UseVisualStyleBackColor = true;
            this.buttonまずここ.Click += new System.EventHandler(this.buttonまずここ_Click);
            // 
            // button貼り付け
            // 
            this.button貼り付け.Location = new System.Drawing.Point(232, 32);
            this.button貼り付け.Name = "button貼り付け";
            this.button貼り付け.Size = new System.Drawing.Size(75, 23);
            this.button貼り付け.TabIndex = 4;
            this.button貼り付け.Text = "貼り付け";
            this.button貼り付け.UseVisualStyleBackColor = true;
            this.button貼り付け.Click += new System.EventHandler(this.button貼り付け_Click);
            // 
            // textBoxURL
            // 
            this.textBoxURL.Location = new System.Drawing.Point(12, 8);
            this.textBoxURL.Name = "textBoxURL";
            this.textBoxURL.ReadOnly = true;
            this.textBoxURL.Size = new System.Drawing.Size(768, 19);
            this.textBoxURL.TabIndex = 5;
            // 
            // textBoxメッセージ
            // 
            this.textBoxメッセージ.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxメッセージ.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBoxメッセージ.Location = new System.Drawing.Point(12, 277);
            this.textBoxメッセージ.Name = "textBoxメッセージ";
            this.textBoxメッセージ.Size = new System.Drawing.Size(768, 24);
            this.textBoxメッセージ.TabIndex = 6;
            this.textBoxメッセージ.Text = "読み込み中";
            this.textBoxメッセージ.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(313, 32);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(58, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "更新";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button初期ページ
            // 
            this.button初期ページ.Location = new System.Drawing.Point(12, 32);
            this.button初期ページ.Name = "button初期ページ";
            this.button初期ページ.Size = new System.Drawing.Size(115, 23);
            this.button初期ページ.TabIndex = 8;
            this.button初期ページ.Text = "初期ページへ移動";
            this.button初期ページ.UseVisualStyleBackColor = true;
            this.button初期ページ.Click += new System.EventHandler(this.button初期ページ_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 62);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 21;
            this.dataGridView1.Size = new System.Drawing.Size(768, 134);
            this.dataGridView1.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button初期ページ);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBoxメッセージ);
            this.Controls.Add(this.textBoxURL);
            this.Controls.Add(this.button貼り付け);
            this.Controls.Add(this.buttonまずここ);
            this.Controls.Add(this.webBrowser1);
            this.Name = "Form1";
            this.Text = "入管通報";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Button buttonまずここ;
        private System.Windows.Forms.Button button貼り付け;
        private System.Windows.Forms.TextBox textBoxURL;
        private System.Windows.Forms.TextBox textBoxメッセージ;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button初期ページ;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}

