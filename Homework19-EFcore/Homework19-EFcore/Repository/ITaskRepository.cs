using Model;

namespace Homework20_EFcore.Repository
{
    public interface ITaskRepository
    {
        public int AddTask(Tasks task);
        public int AddPerson(Person person);
        public List<Tasks> GetAllTasks();
        public int UpdateTask(Tasks task);
        public int DeleteTask(int id);
        public int DeleteAllTasks(bool status);

    }
}
