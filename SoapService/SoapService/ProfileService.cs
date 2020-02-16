using DataBase.DataAccess;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SoapService
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Service1" в коде и файле конфигурации.
    public class ProfileService : ISplit, IInfo, IAuth
    {
        public string[] Text(string str)
        {
            return str.Split(' ');
        }

        public Profiles[] GetInfo()
        {
            using (var context  = new UserContext())
            {
                var obj = context.Profiles.ToArray();
                
                return obj;
            }
        }

        public string PostInfo(long iin, string surname, string firstname, string patronymic)
        {
            try
            {
                using (var context = new UserContext())
                {
                    if (!context.Profiles.Any(p => p.IIN == iin))
                    {
                        context.Profiles.Add(new Profiles
                        {
                            IIN = iin,
                            FirstName = firstname,
                            Surname = surname,
                            Patronymic = patronymic
                        });
                        context.SaveChanges();

                        return "Cохранено";
                    }
                    else
                    {
                        return "Дубликат";
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine("Ошибка");
                return exception.Message;
            }
        }

        public string Register(string username, string password)
        {
            try
            {
                using (var context = new UserContext())
                {
                    if (!context.Users.Any(u => u.UserName == username && u.Password == password))
                    {
                        context.Users.Add(new User
                        {
                            UserName = username,
                            Password = password
                        });
                        context.SaveChanges();

                        return "Вы успешно зарегистрированы";
                    }
                    else
                    {
                        return "Такой пользователь уже существует";
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine("Ошибка регистрации");
                return exception.Message;
            }
        }

        public string Login(string username, string password)
        {
            try
            {
                using (var context = new UserContext())
                {
                    if (context.Users.Any(u => u.UserName == username && u.Password == password))
                    {
                        return "Вы успешно вошли";
                    }
                    else
                    {
                        return "Зарегистрируйтесь, такой User не зарегистрирован";
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine("Ошибка входа");
                return exception.Message;
            }
        }
    } 
}
    
