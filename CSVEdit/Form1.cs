using TailwindCS;

namespace CSVEdit
{
    public partial class Form1 : Form
    {
        private int[,] csvData;

        Dictionary<string, int> TileMapDict = new Dictionary<string, int>
        {
            { "No Room", 0 },
            { "DataDisruptor", 1 },
            { "Nova", 2 },
            { "SizeNode1", 3 },
            { "Drill", 4 },
            { "PowerNode1", 5 },
            { "MultiDisruptor", 6 },
            { "HealthNode1", 7 },
            { "HealthNodeFragment1", 8 },
            { "Kilver", 9 },
            { "HealthNodeFragment4", 10 },
            { "AddressDisruptor1", 11 },
            { "HealthNodeFragment2", 12 },
            { "PowerNodeFragment7", 13 },
            { "HealthNode2", 14 },
            { "SizeNode2", 15 },
            { "Note15", 16 },
            { "Note24", 17 },
            { "HealthNodeFragment3", 18 },
            { "PowerNode2", 19 },
            { "HighJump", 20 },
            { "FireWall", 21 },
            { "Note10", 22 },
            { "HealthNodeFragment14", 23 },
            { "GlitchTeleport", 24 },
            { "Note14", 25 },
            { "Note7", 26 },
            { "RangeNode1", 27 },
            { "RangeNode2", 28 },
            { "TendrilsTop", 29 },
            { "HealthNodeFragment7", 30 },
            { "SizeNode3", 31 },
            { "HealthNode3", 32 },
            { "PowerNode3", 33 },
            { "DroneGun", 34 },
            { "Note16", 35 },
            { "PowerNodeFragment3", 36 },
            { "Note28", 37 },
            { "HealthNodeFragment6", 38 },
            { "HealthNodeFragment5", 39 },
            { "PasswordTool", 40 },
            { "Note19", 41 },
            { "Note20", 42 },
            { "Voranj", 43 },
            { "HealthNodeFragment10", 44 },
            { "VerticalSpread", 45 },
            { "HealthNodeFragment8", 46 },
            { "AddressDisruptor2", 47 },
            { "PowerNodeFragment5", 48 },
            { "PowerNodeFragment6", 49 },
            { "InertialPulse", 50 },
            { "PowerNodeFragment8", 51 },
            { "HealthNodeFragment9", 52 },
            { "HealthNode4", 53 },
            { "Grapple", 54 },
            { "Note25", 55 },
            { "HealthNodeFragment13", 56 },
            { "PowerNodeFragment1", 57 },
            { "TetheredCharge", 58 },
            { "Note13", 59 },
            { "HealthNodeFragment12", 60 },
            { "HealthNodeFragment11", 61 },
            { "PowerNode4", 62 },
            { "Note17", 63 },
            { "PowerNodeFragment14", 64 },
            { "Reflect", 65 },
            { "EnhancedLaunch", 66 },
            { "BlackCoat", 67 },
            { "RangeNode4", 68 },
            { "PowerNodeFragment9", 69 },
            { "Note12", 70 },
            { "PowerNodeFragment16", 71 },
            { "Note9", 72 },
            { "Note22", 73 },
            { "PowerNodeFragment15", 74 },
            { "PowerNodeFragment13", 75 },
            { "HealthNodeFragment16", 76 },
            { "HealthNode5", 77 },
            { "Note8", 78 },
            { "Note23", 79 },
            { "HealthNodeFragment18", 80 },
            { "Note18", 81 },
            { "Note27", 82 },
            { "GlitchBomb", 83 },
            { "HealthNode9", 84 },
            { "LightningGun", 85 },
            { "PowerNodeFragment4", 86 },
            { "PowerNode5", 87 },
            { "HealthNode6", 88 },
            { "RangeNode3", 89 },
            { "Shards", 90 },
            { "Note5", 91 },
            { "DroneTeleport", 92 },
            { "HealthNodeFragment19", 93 },
            { "DistortionField", 94 },
            { "Note2", 95 },
            { "DataGrenade", 96 },
            { "TriCone", 97 },
            { "Note4", 98 },
            { "HealthNode7", 99 },
            { "PowerNodeFragment17", 100 },
            { "TendrilsBottom", 101 },
            { "HealthNodeFragment20", 102 },
            { "Note1", 103 },
            { "Note3", 104 },
            { "BreachSuppressor", 105 },
            { "PowerNode6", 106 },
            { "HealthNodeFragment17", 107 },
            { "RedCoat", 108 },
            { "IonBeam", 109 },
            { "PowerNodeFragment10", 110 },
            { "PowerNodeFragment18", 111 },
            { "HealthNode8", 112 },
            { "PowerNodeFragment11", 113 },
            { "Note6", 114 },
            { "PowerNodeFragment12", 115 },
            { "SizeNode4", 116 },
            { "Note26", 117 },
            { "Scythe", 118 },
            { "Note21", 119 },
            { "Note11", 120 },
            { "WallTrace", 121 },
            { "PowerNodeFragment2", 122 },
            { "FlameThrower", 123 },
            { "Swim", 124 },
            { "HealthNodeFragment15", 125 },
            { "Item Room", 126 },
            { "No Item Room", 127 },
            { "Save Room", 128 },
            { "Boss Room", 129 },
            { "Start", 130 },
            { "Special", 131 }
        };

        public Form1()
        {
            InitializeComponent();
            ValueTileID.DataSource = TileMapDict.ToList();
            ValueTileID.DisplayMember = "Key";
            ValueTileID.ValueMember = "Value";
            // Register the ResizeEnd event handler
            this.ResizeEnd += new EventHandler(Form1_ResizeEnd);
        }

        private int[,] ReadCSVFile(string fileName)
        {
            int[,] data = null;

            try
            {
                List<string> lines = new List<string>();
                using (StreamReader reader = new StreamReader(fileName))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        lines.Add(line);
                    }
                }

                int x = lines[0].Split(',').Length;
                int y = lines.Count;
                data = new int[x, y];

                for (int i = 0; i < y; i++)
                {
                    string[] values = lines[i].Split(',');
                    for (int j = 0; j < x; j++)
                    {
                        int.TryParse(values[j], out data[j, i]);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.Message);
            }

            return data;
        }

        public void GenerateCsvData(int x, int y, string fileName)
        {
            int[,] data = new int[x, y];

            // Generate data rows
            for (int i = 0; i < y; i++)
            {
                for (int j = 0; j < x; j++)
                {
                    data[j, i] = 0;
                }
            }

            csvData = data;
            WriteCsvFile(fileName);
        }

        public void WriteCsvFile(string fileName)
        {
            using (StreamWriter file = new StreamWriter(fileName))
            {
                int numRows = csvData.GetLength(1);
                int numCols = csvData.GetLength(0);

                for (int i = 0; i < numRows; i++)
                {
                    for (int j = 0; j < numCols; j++)
                    {
                        file.Write(csvData[j, i]);
                        if (j < numCols - 1)
                        {
                            file.Write(",");
                        }
                    }
                    file.Write("\n");
                }
            }
        }

        private void LoadCSV_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV files (*.csv)|*.csv";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialog.FileName;
                csvData = ReadCSVFile(fileName);
                if (csvData != null)
                {
                    ValueX.Value = csvData.GetLength(0);
                    ValueY.Value = csvData.GetLength(1);
                    DrawMap();
                }
            }
        }

        private void NewCSV_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV files (*.csv)|*.csv";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = saveFileDialog.FileName;
                GenerateCsvData((int)ValueX.Value, (int)ValueY.Value, fileName);
                if (csvData != null)
                {
                    DrawMap();
                }
            }
        }

        private void UpdateTileID(int x, int y, int id)
        {
            csvData[x, y] = id;
            // MessageBox.Show($"X: {x} | Y: {y} | ID: {csvData[x, y]}");
            DrawMap();
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            int[] tagValues = (int[])button.Tag;
            int x = tagValues[0];
            int y = tagValues[1];
            int cellValue = tagValues[2];
            LocationXValue.Value = x;
            LocationYValue.Value = y;
            ValueTileID.SelectedIndex = cellValue;
        }

        private void Button_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.D1:
                    ValueTileID.SelectedIndex = 127;
                    UpdateTileID((int)LocationXValue.Value, (int)LocationYValue.Value, (int)ValueTileID.SelectedIndex);
                    break;
                case Keys.D2:
                    ValueTileID.SelectedIndex = 126;
                    UpdateTileID((int)LocationXValue.Value, (int)LocationYValue.Value, (int)ValueTileID.SelectedIndex);
                    break;
                case Keys.D3:
                    ValueTileID.SelectedIndex = 128;
                    UpdateTileID((int)LocationXValue.Value, (int)LocationYValue.Value, (int)ValueTileID.SelectedIndex);
                    break;
                case Keys.D4:
                    ValueTileID.SelectedIndex = 129;
                    UpdateTileID((int)LocationXValue.Value, (int)LocationYValue.Value, (int)ValueTileID.SelectedIndex);
                    break;
                case Keys.D5:
                    ValueTileID.SelectedIndex = 131;
                    UpdateTileID((int)LocationXValue.Value, (int)LocationYValue.Value, (int)ValueTileID.SelectedIndex);
                    break;
                case Keys.D9:
                    ValueTileID.SelectedIndex = 1;
                    UpdateTileID((int)LocationXValue.Value, (int)LocationYValue.Value, (int)ValueTileID.SelectedIndex);
                    break;
                case Keys.D0:
                    ValueTileID.SelectedIndex = 0;
                    UpdateTileID((int)LocationXValue.Value, (int)LocationYValue.Value, (int)ValueTileID.SelectedIndex);
                    break;
                default:
                    break;
            }
        }

        private void DrawMap()
        {
            if (csvData == null) return;
            Map.Controls.Clear();
            Console.WriteLine("Drawing map...");

            int mapColumns = csvData.GetLength(1);
            int mapRows = csvData.GetLength(0);
            int squareSize = 16;

            Console.WriteLine($"Map size: {mapColumns}x{mapRows}");

            // Bitmap mapBitmap = new Bitmap(mapColumns * squareSize, mapRows * squareSize);
            // Graphics g = Graphics.FromImage(mapBitmap);

            // List<int> columnValues = new List<int>();
            for (int x = 0; x < mapColumns; x++)
            {
                for (int y = 0; y < mapRows; y++)
                {
                    int cellValue = csvData[y, x];
                    // columnValues.Add(cellValue);
                    // MessageBox.Show($"Drawing square at ({x}, {y}) with value {cellValue}");
                    Rectangle rect = new Rectangle(y * squareSize, x * squareSize, squareSize, squareSize);
                    Rectangle rectInside = new Rectangle(rect.X + 1, rect.Y + 1, rect.Width - 2, rect.Height - 2);
                    Rectangle ellipseRect = new Rectangle(rect.X + rect.Width / 4, rect.Y + rect.Height / 4, rect.Width / 2, rect.Height / 2);

                    Color border = TWColors.stone300;
                    Color background = TWColors.stone800;
                    Button button = new Button();
                    button.Dock = DockStyle.None;
                    button.Anchor = AnchorStyles.None;
                    button.FlatStyle = FlatStyle.Flat;
                    button.Tag = new int[] { y, x, cellValue };
                    button.Click += new EventHandler(Button_Click);
                    button.Size = new Size(rect.Width, rect.Height);
                    button.Location = new Point(rect.X + (rect.Width - button.Width) / 2, rect.Y + (rect.Height - button.Height) / 2);
                    button.KeyUp += Button_KeyUp;

                    if (cellValue >= 1 && cellValue <= 125)
                    {
                        border = TWColors.rose300;
                        background = TWColors.red700;
                    }
                    if (cellValue == 126)
                    {
                        border = TWColors.rose300;
                        background = TWColors.green500;
                    }
                    if (cellValue == 127)
                    {
                        border = TWColors.rose300;
                        background = TWColors.rose600;
                    }
                    if (cellValue == 128)
                    {
                        border = TWColors.cyan300;
                        background = TWColors.cyan500;
                    }
                    if (cellValue == 129)
                    {
                        border = TWColors.red300;
                        background = TWColors.red700;
                    }
                    if (cellValue == 130)
                    {
                        border = TWColors.yellow300;
                        background = TWColors.sky500;
                    }
                    if (cellValue == 131)
                    {
                        border = TWColors.indigo300;
                        background = TWColors.indigo400;
                    }
                    button.BackColor = background;
                    button.FlatAppearance.BorderColor = border;
                    Map.Controls.Add(button);
                }
                // MessageBox.Show($"Column {x}: {string.Join(", ", columnValues)}");
                // columnValues.Clear();
            }

            // Assign the Bitmap to the control's BackgroundImage property
            // Map.BackgroundImage = mapBitmap;
        }

        private void UpdateTileID_Click(object sender, EventArgs e)
        {
            UpdateTileID((int)LocationXValue.Value, (int)LocationYValue.Value, (int)ValueTileID.SelectedValue);
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV files (*.csv)|*.csv";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = saveFileDialog.FileName;
                WriteCsvFile(fileName);
            }
        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            DrawMap();
            Map.ResumeLayout();
        }

        private void Form1_ResizeBegin(object sender, EventArgs e)
        {
            Map.SuspendLayout();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ValueTileID.SelectedIndex = 127;
            UpdateTileID((int)LocationXValue.Value, (int)LocationYValue.Value, (int)ValueTileID.SelectedIndex);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ValueTileID.SelectedIndex = 126;
            UpdateTileID((int)LocationXValue.Value, (int)LocationYValue.Value, (int)ValueTileID.SelectedIndex);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ValueTileID.SelectedIndex = 128;
            UpdateTileID((int)LocationXValue.Value, (int)LocationYValue.Value, (int)ValueTileID.SelectedIndex);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ValueTileID.SelectedIndex = 129;
            UpdateTileID((int)LocationXValue.Value, (int)LocationYValue.Value, (int)ValueTileID.SelectedIndex);
        }
    }
}