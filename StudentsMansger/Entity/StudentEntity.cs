using System;
using System.Collections.Generic;
using System.Text;

namespace StudentsMansger.Entity
{
    class StudentEntity
    {
        private int id;
        private string rollNumber;
        private string name;
        private int gender;
        private string phone;
        private string email;
        private string address;
        private string createdAt;
        private string updatedAt;

        public StudentEntity(int id, string rollNumber, string name, int gender, string phone, string email, string address)
        {
            this.id = id;
            this.rollNumber = rollNumber;
            this.name = name;
            this.gender = gender;
            this.phone = phone;
            this.email = email;
            this.address = address;
        }

        public StudentEntity(int id, string rollNumber, string name, int gender, string phone, string email, string address, string createdAt, string updatedAt)
        {
            this.id = id;
            this.rollNumber = rollNumber;
            this.name = name;
            this.gender = gender;
            this.phone = phone;
            this.email = email;
            this.address = address;
            this.createdAt = createdAt;
            this.updatedAt = updatedAt;
        }

        public int Id { get => id; set => id = value; }
        public string RollNumber { get => rollNumber; set => rollNumber = value; }
        public string Name { get => name; set => name = value; }
        public int Gender { get => gender; set => gender = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Email { get => email; set => email = value; }
        public string Address { get => address; set => address = value; }
        public string CreatedAt { get => createdAt; set => createdAt = value; }
        public string UpdatedAt { get => updatedAt; set => updatedAt = value; }
    }
}
