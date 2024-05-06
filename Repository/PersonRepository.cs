using cerazoT1.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cerazoT1.Repository
{
    public class PersonRepository
    {
        string _dbPath;
        private SQLiteConnection connection;

        public string statusMessage { get; set; }

        public void Init()
        {
            if (connection is not null)
                return;
            connection = new(_dbPath);
            connection.CreateTable<Person>();
        }

        public PersonRepository(string dbPath)
        {
            _dbPath = dbPath;
        }

        public void AddNewPerson(string name, string lastname, string email)
        {
            int result = 0;
            try
            {
                Init();
                if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(lastname) || string.IsNullOrEmpty(email))
                    throw new Exception("Ingrese todos los campos requeridos");
                Person person = new() { 
                    Name = name, 
                    Lastname = lastname, 
                    Email = email 
                };
                result = connection.Insert(person);
                statusMessage = string.Format("Dato agregado corectamente:\n", result, name);
            }
            catch (Exception ex)
            {
                statusMessage = string.Format("Error, no se pudo ingresar el registro:\n ", name, ex.Message);
            }
        }

        public void UpdatePerson(Person person)
        {
            int result = 0;
            try
            {
                Init();
                if (string.IsNullOrEmpty(person.Name) || string.IsNullOrEmpty(person.Lastname) || string.IsNullOrEmpty(person.Email))
                    throw new Exception("Ingrese todos los campos requeridos");
                result = connection.Update(person);
                statusMessage = string.Format("Dato actualizado corectamente:\n", result);
            }
            catch (Exception ex)
            {
                statusMessage = string.Format("Error, no se pudo actualizar el registro:\n ", ex.Message);
            }
        }

        public void DeletePerson(Person person)
        {
            int result = 0;
            try
            {
                Init();
                result = connection.Delete(person);
                statusMessage = string.Format("Dato eliminado corectamente:\n", result);
            }
            catch (Exception ex)
            {
                statusMessage = string.Format("Error, no se pudo eliminar el registro:\n ", ex.Message);
            }
        }

        public List<Person> GetPerson()
        {
            try
            {
                Init();
                return connection.Table<Person>().ToList();
            }
            catch (Exception ex)
            {
                statusMessage = string.Format("Error, al listar los datos", ex.Message);
            }
            return new List<Person>();
        }

    }
}
