using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;

namespace task8_television
{
    public class Television
    {
        // Properties
        public bool powerOn { get; private set; }
        public int channel { get; private set; }
        public int volume { get; private set; }

        // Constructors
        public Television()
        {
           
        }

        // Methods
        public void TurnOn()
        {
            powerOn = true;
        }

        public void TurnOff()
        {
            powerOn = false;
            channel = 0; // set channel to 0 when powered off
            volume = 0; // set volume to 0 when powered off
        }

        public void SetVolume(int volume)
        {   
            if (powerOn)
            {
                if (volume > 100)
                {
                    volume = 100;
                }
                else if (volume < 0)
                {
                    volume = 0;
                }
                else
                {
                    this.volume = volume;
                }
            }
            
        }

        public void SetChannel(int channel)
        {
            if (powerOn) 
            {
                this.channel = channel;
            }
            else
            {
                channel = 0;
            }

        }

        public override string ToString()
        {
            return $"Power: {(powerOn ? "On" : "Off")}, Channel: {channel}, Volume level: {volume}\n";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {   
            // create television with default settings
            Television television = new Television();
            television.TurnOn();
            Console.WriteLine(television.ToString());
            television.SetChannel(2);
            television.SetVolume(150);
            Console.WriteLine(television.ToString());
            television.SetChannel(4);
            television.SetVolume(23);
            Console.WriteLine(television.ToString());
            television.TurnOff();
            Console.WriteLine(television.ToString());
            
        }
    }
}
