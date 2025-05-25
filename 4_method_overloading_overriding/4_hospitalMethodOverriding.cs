
    class Hospital
    {
        public virtual void HospitalDetails()
        {
            Console.WriteLine("Hospital");
        }
    }
    class Apollo : Hospital
    {
        override public void HospitalDetails()
        {
            Console.WriteLine("Appolo");
        }
    }
    class Wockhardt : Hospital
    {
        override public void HospitalDetails()
        {
            Console.WriteLine("Wockhardt");
        }
    }
    class Gokul_Superspeciality : Hospital
    {
        override public void HospitalDetails()
        {
            Console.WriteLine("Gokul Superspeciality");
        }
    }


Hospital hospital = new Hospital();
Apollo apollo = new Apollo();
Wockhardt wockhardt = new Wockhardt();
Gokul_Superspeciality gokul_Superspeciality = new Gokul_Superspeciality();

hospital.HospitalDetails();
apollo.HospitalDetails();
wockhardt.HospitalDetails();
gokul_Superspeciality.HospitalDetails();
