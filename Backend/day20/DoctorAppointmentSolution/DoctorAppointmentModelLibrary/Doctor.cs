namespace DoctorAppointmentModelLibrary
{
    public class Doctor
    {
         public int DoctorId { get; set; }    
         public string Name { get; set; }   
         
        public string Specialization{ get; set; }
        public double Experience {  get; set; }
        public double Fees { get; set; }
        public bool AvailableToday { get; set; }
        

        public Doctor()
        {
            DoctorId = 0;
            Name = string.Empty;
            Specialization = string.Empty;
            Experience = 0;
            Fees = 0;
            AvailableToday = false;
        }

        public Doctor(int id, string name, string specialization, double experience, double fees, bool availableToday)
        {
            DoctorId = id;
            Name = name;
            Specialization = specialization;
            Experience = experience;
            Fees = fees;
            AvailableToday = availableToday;
            
        }

        public virtual void BuildDoctorFromConsole()
        {
            Console.WriteLine("------------------------------");
            Console.WriteLine("Enter Doctor's Name");
            Name= Console.ReadLine()?? String.Empty;

            Console.WriteLine("Enter Doctor's Specialization");
            Specialization= Console.ReadLine()?? String.Empty;

            Console.WriteLine("Enter Doctor's Experience ");
            double experience=0;
            while(!double.TryParse(Console.ReadLine(),out experience))
            {
                Console.WriteLine("Wrong Entry !! Try Again");
            }
            Experience=experience;

            double fees=0;
            while (!double.TryParse(Console.ReadLine(), out fees))
            {
                Console.WriteLine("Wrong Entry !! Try Again");
            }
            Fees = fees;


        }
        public virtual void PrintDoctorDetails()
        {
            Console.WriteLine("--------------------------------");
            Console.WriteLine("Doctor's Id " + DoctorId);
            Console.WriteLine("Doctor's Name " + Name);
            Console.WriteLine("Doctor's Specialization " + Specialization);
            Console.WriteLine("Doctor's Experince " + Experience);
            Console.WriteLine("Doctor's Fees " + Fees);
        }

        public override string ToString()
        {
            return "\nDoctor's Id " + DoctorId+
               "\nDoctor's Name " + Name+
                "\nDoctor's Specialization " + Specialization+
                "\nDoctor's Experince " + Experience+
                "\nDoctor's Fees " + Fees;
        }
    }
}
