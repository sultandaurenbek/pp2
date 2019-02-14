using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager
{
    enum Mode //creating enum to know is it dir or file when pressing enter
    {
        DIR,
        FILE
    }
    class layer
    {
        public string filecontent; // string save text from file when opening file
        private int selecteditem = 0;
        private List<FileSystemInfo> items;
        public List<FileSystemInfo> Items // property for getting items
        {
            get
            {
                return items;//property for getting items
            }
        }
        //property for getting and setting the value of selected item
        public int SelectedItem
        {
            get
            {
                return selecteditem; // define selected item
            }
            set
            {
                if (value < 0) selecteditem = items.Count - 1;// exception when we go up over limit return cursor to the end
                else
                {
                    if (value >= items.Count) selecteditem = 0;// when we go down and over limit return cursor to begin
                    else selecteditem = value;
                }

            }
        }
        public layer(DirectoryInfo dirinfo) //constructor
        {
            FileSystemInfo[] arrayItemS = dirinfo.GetFileSystemInfos();
            List<FileSystemInfo> listItems = new List<FileSystemInfo>();
            listItems.AddRange(arrayItemS);//converting array into list
            this.items = listItems; // getting value
        }
        public void delete(FileSystemInfo sys)//method for deleting 
        {
            if (sys.GetType() == typeof(DirectoryInfo))
            {
                Directory.Delete(sys.FullName, true);//deleting directory
            }
            else
            {
                File.Delete(sys.FullName);//deleting file
            }
            items.RemoveAt(selecteditem); //removing filesysteminfo from list at current index    
        }
        public void rename(FileSystemInfo fInfo)//method for renaming
        {
            Console.BackgroundColor = ConsoleColor.Black;
            if (fInfo.GetType() == typeof(DirectoryInfo))
            {
                DirectoryInfo y = fInfo as DirectoryInfo;
                for (int i = 1; i <= 2; i++) // creating space for writing name from console
                {
                    Console.WriteLine();
                }
                for (int i = 0; i < 20; i++)
                {
                    Console.Write("  ");
                }
                Console.Write("Enter new name:"); //writing in console for user 

                string s = Console.ReadLine(); // new  name that user wrote
                string path = y.Parent.FullName; // location of this directory
                
                string newname = Path.Combine(path, s); // because there is no command in c# for juct renaming name od diredctory
                y.MoveTo(newname); // we will move file to the same path with new name
            }
            else
            {
                FileInfo y = fInfo as FileInfo; 
                for (int i = 1; i <= 2; i++) // creating space for writing name from console
                {
                    Console.WriteLine();
                }
                for (int i = 0; i < 20; i++)
                {
                    Console.Write("  ");
                }
                Console.Write("Enter new name:"); //writing in console for user 

                string s = Console.ReadLine();
                string newname = Path.Combine(y.Directory.FullName, s);
                y.MoveTo(newname); // there is no defalut function for rename in C# 
            }
        }

        public string openingFile(FileInfo f) // method for reading file
        {
            FileStream fs = new FileStream(f.FullName, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            string s = sr.ReadToEnd(); //reading file and saving it into string
            fs.Close();
            sr.Close();
            return s; //saving it into string filecontent       
        }
       
       
        public void Draw(Mode caase) // method for visualization
        {
            if (caase == Mode.FILE)
            {
                Console.BackgroundColor = ConsoleColor.White; // background color
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Black; // text color
                Console.Write(filecontent); // output the text from textfile
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Black; 
                Console.Clear();
                for (int i = 0; i < items.Count; i++)
                {
                    if (i == selecteditem) // selected item
                    {
                        Console.BackgroundColor = ConsoleColor.Blue; // cursor color
                    }
                    else Console.BackgroundColor = ConsoleColor.Black;
                    if (items[i].GetType() == typeof(DirectoryInfo))
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow; // directory color
                    }
                    else Console.ForegroundColor = ConsoleColor.White; // files color
                    Console.WriteLine(items[i].Name); // output content of directory
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo dirinfo = new DirectoryInfo(@"C:\Users\Sultan\Desktop\Intel");
            Stack<layer> history = new Stack<layer>(); //creating stack for saving layers
            Mode Case = Mode.DIR; // initially its directory mode
            history.Push(new layer(dirinfo)); 
            bool quit = false;
            while (!quit) 
            {
                history.Peek().Draw(Case); // prorisovka
                ConsoleKeyInfo pressedKey = Console.ReadKey();
                switch (pressedKey.Key)
                {
                    case ConsoleKey.UpArrow:
                        history.Peek().SelectedItem--; 
                        break;
                    case ConsoleKey.DownArrow:
                        history.Peek().SelectedItem++;
                        break;
                    case ConsoleKey.Enter: // there are two situation entering to directory or file
                        int x = history.Peek().SelectedItem; // selected item saving in to x
                        FileSystemInfo y = history.Peek().Items[x] as FileSystemInfo; // saving value in to y
                        if (y.GetType() == typeof(DirectoryInfo))//if its directory then creating new layer of directory and pushing it into stack
                        {
                            DirectoryInfo d = y as DirectoryInfo; // converting filesysteminfo to directoryinfo
                            history.Push(new layer(d));
                        }
                        else//if its file we will draw content of file
                        {
                            FileInfo f = y as FileInfo; // converting filesysteminfo to fileinfo 
                            history.Peek().filecontent = history.Peek().openingFile(f); // save text from textfile in to string filecontent
                            Case = Mode.FILE; // swithing mode from directory to file
                        }
                        break;
                    case ConsoleKey.Backspace: //there are two situations first exit from directory or exit from file 
                        if (Case == Mode.DIR) // if its directory then we will return previous layer of stack
                        {
                            if (history.Count() > 1) // exception in order to avoid empty stack
                            {
                                history.Pop(); // deleate last layer from stack 
                            }
                        } // if its file then it will return the last layer of stack
                        else
                        {
                            Case = Mode.DIR; // switching directory mode 
                        }
                        break;
                    case ConsoleKey.Delete: // command for deleting
                        int n = history.Peek().SelectedItem; 
                        FileSystemInfo fi = history.Peek().Items[n];
                        history.Peek().delete(fi); // calling method delete
                        break;
                    case ConsoleKey.F2: // console key for renaming
                        int b = history.Peek().SelectedItem;
                        FileSystemInfo fi1 = history.Peek().Items[b];
                        history.Peek().rename(fi1);// calling method rename
                        break;
                    case ConsoleKey.Escape: // the end
                        quit = true;
                        break;
                }
            }
        }
    }
}
