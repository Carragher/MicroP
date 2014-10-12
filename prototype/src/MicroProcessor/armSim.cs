using System;
using System.Runtime.InteropServices;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.Diagnostics;
using System.Windows.Forms;
using System.Threading;

namespace armsim
{
    //this class works as a storage device for hardware variables E.g ram and Cpu
    // It also works as the buffer that stops the gui from directly accessing the model

    class Computer
    {

        public static StreamWriter log;
        public static StreamWriter Trace;
        public static Memory outerRam;
        public static Register r0;
        public static Register r1;
        public static Register r2;
        public static Register r3;
        public static Register r4;
        public static Register r5;
        public static Register r6;
        public static Register r7;
        public static Register r8;
        public static Register r9;
        public static Register r10;
        public static Register r11;
        public static Register r12;
        public static Register r13;
        public static Register r14;
        public static Register r15;
        public static bool stop;
        public static CPU processor;
        public static string lastLoadedFile;
        public static bool traceTest;
        public static uint stepCounter;

        public static void setStop()
        {
            if (stop == false)
            {
                stop = true;
            }
            else
            {
                stop = false;
            }
        }

        //this method returns the register data to be used b
        public static byte[] regRead(uint regnum)
        {
            switch (regnum)
            {
                case 0:
                    return r0.returnReg();
                case 1:
                    return r1.returnReg();
                case 2:
                    return r2.returnReg();
                case 3:
                    return r3.returnReg();
                case 4:
                    return r4.returnReg();
                case 5:
                    return r5.returnReg();
                case 6:
                    return r6.returnReg();
                case 7:
                    return r7.returnReg();
                case 8:
                    return r8.returnReg();
                case 9:
                    return r9.returnReg();
                case 10:
                    return r10.returnReg();
                case 11:
                    return r11.returnReg();
                case 12:
                    return r12.returnReg();
                case 13:
                    return r13.returnReg();
                case 14:
                    return r14.returnReg();
                case 15:
                    return r15.returnReg();
            }

            return r0.returnReg();
        }

        //this method is used to grab a specific word from memory to use in gui
        public static uint grabWord(uint address)
        {
            return outerRam.readWord( Convert.ToInt32(address));
        }

        //this method is used to grab the stack pointer
        public static uint stackPointerGet()
        {
            return r13.readWord(0);
        }

        //grabs the bool that turns on tracing
        public static bool getTrace()
        {
            return traceTest;
        }

        // this file reads in a file into memory
        public static void readFile(string fName)
        {
            Computer.log.WriteLine("Loader: reading elf file " + fName);
            ReadElf.ReadELfData(fName, ref Computer.outerRam);
        }

        //this method sets the trace variable
        public static void setTrace(bool set)
        {
            traceTest = set;
        }

        //this method initializes the different variables that are stored in the Computer class
        public static void Init()
        {
            Computer.log.WriteLine("Prototype: Initializing the Computer variables");
            processor = new CPU();
            stop = false;
            lastLoadedFile = "";
            traceTest = true;
            stepCounter = 0;
            
        }
        //ITS CLOBBERING TIME!!!
        public static void clobber()
        {
            Computer.log.WriteLine("Prototype: Reseting the Memory");
           int len = outerRam.RAM.Length;
           for (int x = 0; x < len; x++)
           {
               outerRam.RAM[x] = 0x00;
           }
           byte[] b =BitConverter.GetBytes(outerRam.readWord(0));
           r0.RAM = b;
           r1.RAM = b;
           r2.RAM = b;
           r3.RAM = b;
           r4.RAM = b;
           r5.RAM = b;
           r6.RAM = b;
           r7.RAM = b;
           r8.RAM = b;
           r9.RAM = b;
           r10.RAM = b;
           r11.RAM = b;
           r12.RAM = b;
           r13.RAM = b;
           r14.RAM = b;
           r15.RAM = b;
        
        }
        //this initializes the registers
        public static void initReg()
        {
            Computer.log.WriteLine("Prototype: Initializing the registers");
            Computer.r0 = new Register();
            Computer.r1 = new Register();
            Computer.r2 = new Register();
            Computer.r3 = new Register();
            Computer.r4 = new Register();
            Computer.r5 = new Register();
            Computer.r6 = new Register();
            Computer.r7 = new Register();
            Computer.r8 = new Register();
            Computer.r9 = new Register();
            Computer.r10 = new Register();
            Computer.r11 = new Register();
            Computer.r12 = new Register();
            Computer.r13 = new Register();
            Computer.r14 = new Register();
            Computer.r15 = new Register();

        }

        //This class returns the needed bytes to the gui
        public static byte[] memOut(uint address)
        {
            byte[] ret = new byte[128];
            Array.Copy(outerRam.RAM, address, ret, 0, 128);
            return ret;

        }
        //this method returns the MD5 hash that can set the text box
        public static string HashSet()
        {
            return outerRam.MDhash();
        }

        //Runs the fetch decode execute system in a loop
        public static void run()
        {
            while (!stop)
            {
                Computer.stepCounter += 1;
                Computer.log.WriteLine("Prototype: Running in a loop");
                int addr = Convert.ToInt32(r15.readWord(0));
                uint fetched = processor.fetch(r15.readWord(0));
                addr += 4;
                r15.writeWord(0, Convert.ToUInt32(addr));

                if (fetched == 0)
                {
                    break;
                }
                uint dcded = processor.decode(fetched);
                processor.exectute(dcded);
                if (traceTest)
            {
                Computer.Trace.WriteLine(Computer.stepCounter.ToString().PadLeft(6, '0') + " " + r15.readWord(0).ToString("x8") + " " + Computer.HashSet() +" " + "0000" + " 0=" + r0.readWord(0).ToString("x8") + " 1=" + r1.readWord(0).ToString("x8") + " 2=" + r2.readWord(0).ToString("x8") + " 3=" + r3.readWord(0).ToString("x8"));
                Computer.Trace.WriteLine("4=" + r4.readWord(0).ToString("x8") + " 5=" + r5.readWord(0).ToString("x8") + " 6=" + r6.readWord(0).ToString("x8") + " 7=" + r7.readWord(0).ToString("x8") + " 8=" + r8.readWord(0).ToString("x8") + " 9=" + r9.readWord(0).ToString("x8"));
                Computer.Trace.WriteLine("10=" + r10.readWord(0).ToString("x8") + " 11=" + r11.readWord(0).ToString("x8") + " 12=" + r12.readWord(0).ToString("x8") + " 13=" + r13.readWord(0).ToString("x8") + " 14=" + r14.readWord(0).ToString("x8"));
            }
                
            }
            stop = false;
            if (traceTest)
            {
                Computer.Trace.WriteLine(Computer.stepCounter.ToString().PadLeft(6, '0') + " " + r15.readWord(0).ToString("x8") + " " + Computer.HashSet() + " " + "0000" + " 0=" + r0.readWord(0).ToString("x8") + " 1=" + r1.readWord(0).ToString("x8") + " 2=" + r2.readWord(0).ToString("x8") + " 3=" + r3.readWord(0).ToString("x8"));
                Computer.Trace.WriteLine("4=" + r4.readWord(0).ToString("x8") + " 5=" + r5.readWord(0).ToString("x8") + " 6=" + r6.readWord(0).ToString("x8") + " 7=" + r7.readWord(0).ToString("x8") + " 8=" + r8.readWord(0).ToString("x8") + " 9=" + r9.readWord(0).ToString("x8"));
                Computer.Trace.WriteLine("10=" + r10.readWord(0).ToString("x8") + " 11=" + r11.readWord(0).ToString("x8") + " 12=" + r12.readWord(0).ToString("x8") + " 13=" + r13.readWord(0).ToString("x8") + " 14=" + r14.readWord(0).ToString("x8"));
            }
            
        }
        //runs the fetch decode execute system in one cycle
        /*step_number program_counter checksum nzcf r0 r1 r2 r3
r4 r5 r6 r7 r8 r9
r10 r11 r12 r13 r14
         * 
         * 
         * 
         */
        public static void step()
        {

            Computer.stepCounter += 1;
            Computer.log.WriteLine("Prototype: Running a cycle");
            int addr = Convert.ToInt32(r15.readWord(0));
            uint fetched = processor.fetch(r15.readWord(0));
            addr += 4;
            r15.writeWord(0, Convert.ToUInt32(addr));
            if (fetched != 0)
            { 
                uint dcded = processor.decode(fetched);
                processor.exectute(dcded);
                
            }
            if (traceTest)
            {
                Computer.Trace.WriteLine(Computer.stepCounter.ToString().PadLeft(6, '0') + " " + r15.readWord(0).ToString("x8") + " " + Computer.HashSet() +" " + "0000" + " 0=" + r0.readWord(0).ToString("x8") + " 1=" + r1.readWord(0).ToString("x8") + " 2=" + r2.readWord(0).ToString("x8") + " 3=" + r3.readWord(0).ToString("x8"));
                Computer.Trace.WriteLine("4=" + r4.readWord(0).ToString("x8") + " 5=" + r5.readWord(0).ToString("x8") + " 6=" + r6.readWord(0).ToString("x8") + " 7=" + r7.readWord(0).ToString("x8") + " 8=" + r8.readWord(0).ToString("x8") + " 9=" + r9.readWord(0).ToString("x8"));
                Computer.Trace.WriteLine("10=" + r10.readWord(0).ToString("x8") + " 11=" + r11.readWord(0).ToString("x8") + " 12=" + r12.readWord(0).ToString("x8") + " 13=" + r13.readWord(0).ToString("x8") + " 14=" + r14.readWord(0).ToString("x8"));
            }
            stop = false;


        }


    }

    //this method uses the fetch decode cycle to do things
    class CPU
    {
        bool Glitch;

        public CPU()
        {
            Glitch = false;
        }

        //grabs a word to decode and use an instruction
        public uint fetch(uint address)
        {
            Computer.outerRam.readWord(Convert.ToInt32(address));
            return 0;
        }
        //decodes an instruction
        public uint decode(uint dcd)
        {
            return 0;
        }
        
        //executes the instructions
        public bool exectute(uint inst)
        {
            Thread.Sleep(250);
            return true;
        }

    }


	//A struct of elf Storage varibles. This struct is used to parse the header portion of an ELF  file.
	[StructLayout(LayoutKind.Sequential, Pack = 1)] //For Parsing Header Portion
	public struct ElfStorageFacility
	{

		public uint p_type;
		public uint p_offset; 
		public uint p_vaddr; 
		public uint p_paddr;
		public uint p_filesz;
		public uint p_memsz;
		public uint p_flags;
		public uint p_align;


	}

	// A struct that mimics memory layout of ELF file header
	// See http://www.sco.com/developers/gabi/latest/contents.html for details
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct ELF
	{
		public byte EI_MAG0, EI_MAG1, EI_MAG2, EI_MAG3, EI_CLASS, EI_DATA, EI_VERSION;
		byte unused1, unused2, unused3, unused4, unused5, unused6, unused7, unused8, unused9;
		public ushort e_type;
		public ushort e_machine;
		public uint e_version;
		public uint e_entry;
		public uint e_phoff;
		public uint e_shoff;
		public uint e_flags;
		public ushort e_ehsize;
		public ushort e_phentsize;
		public ushort e_phnum;
		public ushort e_shentsize;
		public ushort e_shnum;
		public ushort e_shstrndx;
	}
	class ReadElf
	{
		public static void ReadELfData(string args, ref Memory mem)
		{


			string elfFilename = args;
			using (FileStream strm = new FileStream(elfFilename, FileMode.Open))
			{
				ELF elfHeader = new ELF();
				byte[] data = new byte[Marshal.SizeOf(elfHeader)];

				// Read ELF header data
				strm.Read(data, 0, data.Length);
				// Convert to struct
				elfHeader = ByteArrayToStructure<ELF>(data);

				Computer.log.WriteLine("Loader: Entry point: " + elfHeader.e_entry.ToString("X4"));
				Computer.log.WriteLine("Loader: Number of program header entries: " + elfHeader.e_phnum);

				strm.Seek(elfHeader.e_phoff, SeekOrigin.Begin);

				ElfStorageFacility[] structArray = new ElfStorageFacility[elfHeader.e_phnum];
				ElfStorageFacility variable = new ElfStorageFacility ();


				for (int x = 0; x < elfHeader.e_phnum; x++) {
					data = new byte[elfHeader.e_phentsize];
					strm.Read(data,0,(int)elfHeader.e_phentsize);
					variable =  ByteArrayToStructure<ElfStorageFacility>(data);
					structArray[x] = variable;
				}

				for (int x = 0; x < structArray.Length; x++)
				{
					strm.Seek(structArray[x].p_offset, SeekOrigin.Begin);
					strm.Read(mem.RAM,(int)structArray[x].p_vaddr, (int)structArray[x].p_filesz);
				}





		}

		}

		// this method transform a bytearray to a the structure so that ELFSTORAGEFACILITY can use it
		static T ByteArrayToStructure<T>(byte[] bytes) where T : struct
		{
			GCHandle handle = GCHandle.Alloc(bytes, GCHandleType.Pinned);
			T stuff = (T)Marshal.PtrToStructure(handle.AddrOfPinnedObject(),
			                                    typeof(T));
			handle.Free();
			return stuff;
		}

	}

	/*THe simRam class mimics real RAM for use in a virtual microproccessor
	 * this class has a public static Byte array that contains the bytes of the vRam that is constructed
	 * at object initialization
	 * 
	 * this class has methods to read and write words/halfwords/bytes to memory.
	 * This class also has a method that returns a MD5 hash that can be used for data integerity testing.
	 * this class also has a method that can test or set individual bits within memory
	 */

	class Memory
	{
		public byte[] RAM;

        public Memory() { ;}

		//instructer that takes a uInt variable and intializes the size of ram with it.
		public Memory(uint size){
			RAM = new byte[size];
		}

		//the method takes in an int address then reads in a full 32bit word from RAM and outputs an unsigned int of the same type.
	 	public uint readWord(int address) {

			return BitConverter.ToUInt32(RAM, address);

		}

		// this method takes in an int address, and a uint word to write to memory, and returns true after finishing
		public bool writeWord(int address, uint writing) {

			byte[] midStep = new byte[4];
			midStep = BitConverter.GetBytes (writing);

			for (int x = 0; x < 4; x++) {
				RAM [address + x] = midStep [x];
			}


			return true;
		}

		// this method is the 16bit version of readword.
		public ushort readHalfWord(int address) {

			return BitConverter.ToUInt16(RAM,address);
		}
		// this method is the 16 bit version of writeword
		public bool writeHalfWord(int address, ushort writing) {

			byte[] midstep = new byte[2];
			midstep = BitConverter.GetBytes (writing);

			for (int x = 0; x<2; x++) {
				RAM [address + x] = midstep [x];
			}

			return true;
		}
		// this is the single byte version of readword.
		public byte readByte(int address) {
			return RAM[address];
		}

		//this is the single byte version of write word
		public bool writeByte(int address, byte writing){

			RAM [address] = writing;
			return true;
		}
		// this method returns a MD5 hash to test the data integrity of the ram
		public string MDhash() {

			MD5 m = MD5.Create();
			byte[] hash = m.ComputeHash(RAM);

			string tst = BitConverter.ToString(hash).Replace("-", "");

			Computer.log.WriteLine("Loader: HASH IS: "+tst);



			return tst;
		}

		//this method takes in an address and a number between 0-31
		// it then goes to the address and checks the bit.
		// if the bit is 1 it returns true
		//else it returns false
		public bool testFlag(int address, short bit){
			byte[] midStep = new byte[4];
			midStep = BitConverter.GetBytes (readWord (address));
			BitArray bity = new BitArray (midStep);
			Computer.log.WriteLine ("Loader: bit equals " + bity [bit]);
			if (bity [bit] == true) {

				return true;

			} else {
				return false;
			}
		}




		//this method takes in an address and a number between 0-31 and a flag that is true or false
		//this method goes to the bit like testflag, then changes the bit to whatever the variable flag is.
		public bool setFlag(int address, short bit, bool flag){
			byte[] midStep = new byte[4];
			midStep = BitConverter.GetBytes (readWord(address));
			BitArray bity = new BitArray (midStep);
			bity [bit] = flag;
			bity.CopyTo (midStep, 0);
			uint rewrite = BitConverter.ToUInt32 (midStep, 0);
			writeWord (address, rewrite);
			return true;
		}

		//this method prints out the entirty of ram to console
		// it is for debugging purposes only.
		public void printRam (){
			Console.WriteLine (RAM.Length);
			for (int x = 0; x<RAM.Length; x++) {
				Console.WriteLine (" ");
				int i = x;
				int y = 0;
				while (i< x+8) {
					Console.Write (" " + RAM[x + y].ToString("x2"));
					i++;
					y++;
					
				}
				x = x+7;

			}
			Console.WriteLine ("");
		}


	}

    //registers are memory except smaller
    class Register : Memory
    {
        
        
        public Register()
        {
            RAM = BitConverter.GetBytes(0x00000000);
          
        }
        

        public byte[] returnReg()
        {

            return RAM;
            
        }



    }


	/* this is a static options class
	 * this class contains one method that is used to parse command line
	 * this class will be expanded as more options requirements are needed
	 * 
	 * 
	 */

	static class options
	{
		public static void parse(string[] cmdline){
			bool parser = true;

			int x = 0;
			int y = 0;
			bool loader = false;
			bool test = false;
			uint memsize = 32768;
			while (parser == true) {
				int len = cmdline.Length;


				switch (cmdline [x].Trim()) {

				case "--test":
					test = true;
					Computer.log.WriteLine ("Loader: Intializing test cases. WARNING Test cases only test test1.exe's hash");



					break;

				case "--mem":


					x++;
					memsize = Convert.ToUInt32 (cmdline [x]);

					break;

				case "--load":

					x++;
					y = x;
					loader = true;

					break;

				default: 
					Computer.log.WriteLine ("you have entered an invalid command line. The current valid commands are --test, --mem [number], load [file] ");
					break;

				}



				x++;
				if (x > len - 1) {
					parser = false;
				}

			}
			Computer.log.WriteLine ("loader: creating ram of size " + memsize);
			Computer.outerRam = new Memory (memsize);

			//
			//ram.printRam ();
			if (loader == true) {
				string file = cmdline [y];
				Computer.log.WriteLine ("Loader: reading elf file " + file);
				ReadElf.ReadELfData (file, ref Computer.outerRam);
                
			}
			if (test == true) {
                Memory mem = new Memory(32768);
                ReadElf.ReadELfData("test1.exe", ref mem);
				string checker = "3500a8bef72dfed358b25b61b7602cf1";
				Debug.Assert (checker == mem.MDhash().ToLower());
				Computer.log.WriteLine ("Loader: MD5 Hash passed");
				mem.writeWord (2, 0xDEADBEEF);
				checker = "deadbeef";
				Debug.Assert(checker == mem.readWord(2).ToString("x2"));
                mem.writeHalfWord(8, 0xCADD);
				checker = "cadd";
				Debug.Assert(checker == mem.readHalfWord(8).ToString("x2"));
                mem.writeByte(0, 0xAB);
				checker = "ab";
				Debug.Assert (checker == mem.readByte (0).ToString("x2"));
                mem.writeWord(0, 0x00000000); // clobbers the already written test cases
                mem.setFlag(0, 19, true);
				bool testie = true;
				Debug.Assert(testie == mem.testFlag(0,19));
				Computer.log.WriteLine ("Loader: We have passed the test cases");
                Register reg = new Register();
                Debug.Assert(0x00000000 == reg.readWord(0));
                CPU c = new CPU();
                Debug.Assert(0x00000000 == c.fetch(0));
                
			}
			
		}
	}

	/*this class is the main class
	 * within is the main method as well as a public static streamwriter used for logging purposes.
	 * the main method is what initializes the program and keeps it running
	 */ 
	class MainClass
	{

		

        [STAThread]
		static void Main (string[] args)
		{
            
			Computer.log = new StreamWriter("log.txt",true);
            Computer.Trace = new StreamWriter("trace.log", false);
            Computer.log.WriteLine("\r\n" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\r\n");
            Computer.log.WriteLine("Loader: initializing per command");
            Computer.Init();
            Computer.initReg();
            
            bool doIRun = true;
            try
            {
                options.parse(args);
            }
            catch
            {
                Computer.log.Write("Prototype: Invalid input detected");
                doIRun = false;
            }
            if (doIRun)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new SimGui());
            }
            Computer.log.Close();
            Computer.Trace.Close();
		}
	}
}

