using TrainingExercise.Model;

namespace TrainingExercise.Controller
{
    public static class UserController
    {
        public static readonly List<User> users =
            new List<User>
                   {
            new User
            {
                Id = 1,
                Name = "Mohammad",
                DateOfBirth = new DateOnly(1987, 5, 16),
                Address = "Yatta, Palestine",
            },
            new User
            {
                Id = 2,
                Name = "Amani",
                DateOfBirth = new DateOnly(1988, 2, 25),
                Address = "Hebron, Palestine",
            },
            new User
            {
                Id = 3,
                Name = "Zaid",
                DateOfBirth = new DateOnly(2016, 3, 7),
                Address = "Ramallah, Palestine",
            }
                   };

        //Get user using id
        //public static User GetUser(int id)
        //{
        //    return users.FirstOrDefault(x => x.Id == id);
        //}
        public static User GetUser(int id)
        {
            return users.Find(x => x.Id == id);
        }

        public static void AddUser(User user)
        {
            if (users.Count() > 0)
                user.Id = users.Max(x => x.Id) + 1;
            else
                user.Id = 0;
            users.Add(user);
        }

        public static void UpdateUser(User user)
        {
            int index = users.FindIndex(x => x.Id == user.Id);
            users[index] = user;
        }
        //delete user
        public static void DeleteUser(int id)
        {
            int index = users.FindIndex(x => x.Id == id);
            users.RemoveAt(index);
        }
    }
}
