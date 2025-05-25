
    class RBI
    {
        public virtual void calculateIntrest()
        {
            Console.WriteLine("Intrest In RBI");
        }
    }
    class HDFC : RBI
    {
        override public void calculateIntrest()
        {
            Console.WriteLine("Intrest In HDFC");
        }
    }
    class SBI : RBI
    {
        override public void calculateIntrest()
        {
            Console.WriteLine("Intrest In SBI");
        }
    }
    class ICICI : RBI
    {
        override public void calculateIntrest()
        {
            Console.WriteLine("Intrest In ICICI");
        }
    }


RBI rBI = new RBI();
HDFC hDFC = new HDFC();
SBI sBI = new SBI();
ICICI iCICI = new ICICI();

rBI.calculateIntrest();
hDFC.calculateIntrest();
sBI.calculateIntrest();
iCICI.calculateIntrest();
