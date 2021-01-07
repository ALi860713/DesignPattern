using System;

namespace Facade
{
    class Program
    {
        static void Main(string[] args)
        {
            var facade = new Computer();
            facade.StartComputer();
        }
    }

    internal class Computer
    {
        private readonly Cpu _cpu;
        private readonly SystemMemory _memory;
        private readonly Bios _bios;

        public Computer()
        {
            _cpu = new Cpu();
            _memory = new SystemMemory();
            _bios = new Bios();
        }

        private const string BootAddress = "/boot/bin";

        public void StartComputer()
        {
            _cpu.Freeze();
            _memory.Load(BootAddress);
            _bios.InitialInOutput();
            _cpu.Execute();
        }
    }

    internal class SystemMemory
    {
        public void Load(string bootAddress)
        {
            Console.WriteLine($"System memory loading {bootAddress}...");
        }
    }

    internal class Cpu
    {
        public void Freeze()
        {
            Console.WriteLine("Cpu freezing...");
        }

        public void Execute()
        {
            Console.WriteLine("Cpu executing...");
        }
    }

    internal class Bios
    {
        public void InitialInOutput()
        {
            Console.WriteLine("Bios initialing input and output system...");
        }
    }
}
