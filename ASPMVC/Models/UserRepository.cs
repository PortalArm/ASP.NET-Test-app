using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace ASPMVC.Models
{
    public class UserRepository
    {

        private int _count;
        private static List<User> Users { get; set; } = new List<User> {
            new User() { Id = 1, Login = "user1", Name = "Evgeniy", Email = "ab4c@gmail.com", Password = "ha1ha" },
            new User() { Id = 2, Login = "user22", Name = "Not Evgeniy", Email = "a2bc@gmail.com", Password = "ha6ha" },
            new User() { Id = 3, Login = "user333", Name = "Not Not Evgeniy", Email = "abc7@gmail.com", Password = "ha78ha" },
            new User() { Id = 4, Login = "user4444", Name = "Relevant", Email = "abc2@gmail.com", Password = "hah3a" },
            new User() { Id = 5, Login = "user55555", Name = "Evgeniy", Email = "abc@gmail.com", Password = "ha12ha" },
        };
        private static PropertyInfo[] _userProps = typeof(User).GetProperties();

        public UserRepository()
        {
            _count = Users.Count + 1;
        }
        public void Add(User user)
        {
            user.Id = _count++;
            Users.Add(user);
        }
        public User GetById(int id) => Users.FirstOrDefault(u => u.Id == id);
        public IEnumerable<User> GetAll() => Users;
        public void Update(User user)
        {
            User old = Users.FirstOrDefault(u => u.Id == user.Id);
            if (old == null)
                throw new KeyNotFoundException();
            //old.Login = user.Login;
            //old.Name = user.Name;
            //old.Password = user.Password;
            //old.Email = user.Email;
            foreach (var prop in _userProps)
                prop.SetValue(old, prop.GetValue(user));
        }
        public void Remove(int id) => Users.RemoveAll(u => u.Id == id);

    }
}