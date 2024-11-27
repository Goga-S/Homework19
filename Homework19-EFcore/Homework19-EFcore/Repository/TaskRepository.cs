
using Data;
using Homework20_EFcore.Repository;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Model;

namespace Homework20_EFcore.Repository
{
    public class TaskRepository : ITaskRepository
    {
        private readonly PersonContext _context;

        public TaskRepository(PersonContext context)
        {
            _context = context;
        }
        public int AddTask(Tasks task)
        {
            var personId = _context.Persons.FirstOrDefault(x => x.Id == task.PersonId);
            if (personId == null)
            {
                return 0;
            } else
            {
                _context.Add(task);
                _context.SaveChanges();
                return task.Id; 

            }
        }

        public int AddPerson(Person person)
        {
            _context.Add(person);
            _context.SaveChanges();
            return person.Id;
        }

        public int DeleteAllTasks(bool status)
        {
            var tasks = _context.Task.Where(t => t.completed == status).ToList();
            if (tasks != null) 
            {
                _context.Remove(tasks);
                _context.SaveChanges();
                return 1;
            } else
            {
                return 0;
            }
        }

        public int DeleteTask(int id)
        {
            var task = _context.Task.FirstOrDefault(t => t.Id == id);
            if (task != null)
            {
                _context.Remove(task);
                _context.SaveChanges();
                return id;
            } else
            {
                return 0;
            }
        }

        public List<Tasks> GetAllTasks()
        {
            var tasks = _context.Task.ToList();
            if(tasks != null)
            {
                return tasks;
            } else 
            return new List<Tasks>();
        }


        public int UpdateTask(Tasks task)
        {
            var tsk = _context.Task.FirstOrDefault(t => t.Id == task.Id);

            if (tsk != null)
            {
                tsk = task;
                _context.SaveChanges();
                return task.Id;
            } else
            {
                return 0;
            }
            
        }

    }
}
