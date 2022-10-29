using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace ExamConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyXmlFile xmlFile = new MyXmlFile();
            IEditor editor = new Editor(xmlFile);
            //editor.NewVictorina();
            //editor.EditVictorina();
            IVictorina newVic = new Victorina();
            newVic = (Victorina)xmlFile.GetVictorina("IT.xml");
            newVic.Path = "IT2.xml";
            newVic.Name = "IT2";
            xmlFile.SaveVictorina(newVic);
        }
    }

    public interface IMassiveVictorins
    {
        IMyXmlFile XmlFile { get; set; }
        List<IVictorina> VictorinaList { get; set; }
    }

    public interface IVictorina
    {
        public IMyXmlFile XmlFile { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        List<IQuestion> questions { get; set; }
        public void Start();
        public void Save();
        public void Load();

    }

    public interface IQuestion
    {
        public string Name { set; get; }
        List<string> variants { get; set; }
        List<int> answers { get; set; }
        public string ToString();
    }

    public interface IUser
    {
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public DateTime BirthDay { get; set; }
        public string ToString();
    }

    public interface IAuth
    {
        IMyXmlFile XmlFile { get; set; }
        public bool GetAuth(IUser user);
        public string GetUserName(IUser user);


    }

    public interface IRegister
    {
        IMyXmlFile XmlFile { get; set; }
        public bool SaveNewUser(IUser user);
        public bool ExistUser(IUser user);

    }
    public interface ISettings
    {
        IMyXmlFile XmlFile { get; set; }
        public bool ChangeUserSettingsPassword(IUser user, string password);
        public bool ChangeUserSettingsBirthDate(IUser user, DateTime date);
        public bool ChangeUserSettingsAll(IUser user, string password, DateTime date);
    }

    public interface IMyXmlFile
    {
        public bool ExistFile(string path);
        public IVictorina GetVictorina(string path);
        public bool SaveVictorina(IVictorina victorina);
        public IUser GetUser(string path);
        public bool SaveUser(string path, IUser user, bool rewrite = false);
        public IResultTable GetResultTable(string path);
        public bool SaveResultTable(string path, IResultTable rt);
        public IMassiveVictorins GetAllVictorins();

    }

    public interface IResultTable
    {
        public string Name { get; set; }
        IMyXmlFile XmlFile { get; set; }
        List<ITableItem> TableItems { get; set; }
        public string Path { get; set; }
        public void SaveResultTable();
        public string Top20(string name);
        public string AllResults(string name);


    }

    public interface ITableItem
    {
        public string Score { get; set; }
        public string NameUser { get; set; }
        public string NameVictorina { get; set; }
        public string ToString();

    }

    public interface IEditor
    {
        IMyXmlFile XmlFile { get; set; }
        IVictorina Victorina { get; set; }
        public void NewVictorina();

        public void SaveVictorina();

        public void EditVictorina();
    }
    /*class Auth : IAuth
    {
        private bool result;

        public IMyXmlFile XmlFile { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool GetAuth(IUser user)
        {
            bool exist = true;
            bool tmp = false;
            IUser element = new IUser("", "");
            if (exist = XmlFile.ExistFile("auth.xml"))
            {
                element = XmlFile.GetUser(user.Name);
            }

            if (element != null)
            {
                tmp = (user.Name == /*("name")[0].*//*element.Name) && (user.Password == element.Password);
                tmp = true;
                //return tmp;
            }
            else
            {
                Console.WriteLine("В системе отсутсвуют пользователи");
                tmp = false;
                return tmp;
            }
        }

        public string GetUserName(IUser user)
        {
            return user.Name;
        }
    }*/
    /*class Register : IRegister
    {
        public IMyXmlFile XmlFile { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool ExistUser(IUser user)
        {
            bool exist = XmlFile.ExistFile("auth.xml");
            if (exist)
            {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load("user.xml");
                bool findUser = false;
            }

        }

        public bool SaveNewUser(IUser user)
        {

        }
    }*/   

 
}
