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
        public static uint programCount;
        public static bool exec;
        public static SimGui sim;
        public static bool inT;
      
        public static bool stt;

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

        public static void regSet(uint regnum, uint val)
        {
            switch (regnum)
            {
                case 0:
                    r0.writeWord(0, val);
                     break;
                case 1:
                     r1.writeWord(0, val);
                     break;
                case 2:
                     r2.writeWord(0, val);
                     break;
                case 3:
                     r3.writeWord(0, val);
                     break;
                case 4:
                     r4.writeWord(0, val);
                     break;
                case 5:
                     r5.writeWord(0, val);
                     break;
                case 6:
                     r6.writeWord(0, val);
                     break;
                case 7:
                     r7.writeWord(0, val);
                     break;
                case 8:
                     r8.writeWord(0, val);
                     break;
                case 9:
                     r9.writeWord(0, val);
                     break;
                case 10:
                     r10.writeWord(0, val);
                     break;
                case 11:
                     r11.writeWord(0, val);
                     break;
                case 12:
                     r12.writeWord(0, val);
                     break;
                case 13:
                     r13.writeWord(0, val);
                     break;
                case 14:
                     r14.writeWord(0, val);
                     break;
                case 15:
                     r15.writeWord(0, val);
                     break;
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
            programCount = 0;
            exec = false;
           
            stt = false;
            
            
        }

        public static void setPcount(uint setter)
        {
            programCount = setter;
            Computer.regSet(15, programCount);
            
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
           byte[] c = BitConverter.GetBytes(Computer.programCount);
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
           r15.RAM = c;
        
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
            Computer.regSet(13, 0x00007000);

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
            Computer.inT = true;
            while (!stop)
            {
                
                Computer.stepCounter += 1;
                Computer.log.WriteLine("Prototype: Running in a loop");
                int addr = Convert.ToInt32(r15.readWord(0));
                uint fetched = processor.fetch(r15.readWord(0));
               
                if (fetched == 0)
                {
                    break;
                }
                Instruction dcded = processor.decode(fetched);
                processor.exectute(dcded);
                r15.writeWord(0, Convert.ToUInt32(addr));
                if (traceTest)
            {
                Computer.Trace.WriteLine(Computer.stepCounter.ToString().PadLeft(6, '0') + " " + r15.readWord(0).ToString("x8").ToUpper() + " " + Computer.HashSet() + " " + "0000" + " 0=" + r0.readWord(0).ToString("x8").ToUpper() + " 1=" + r1.readWord(0).ToString("x8").ToUpper() + " 2=" + r2.readWord(0).ToString("x8").ToUpper() + " 3=" + r3.readWord(0).ToString("x8").ToUpper());
                Computer.Trace.WriteLine("       " + " 4=" + r4.readWord(0).ToString("x8").ToUpper() + " 5=" + r5.readWord(0).ToString("x8").ToUpper() + " 6=" + r6.readWord(0).ToString("x8").ToUpper() + " 7=" + r7.readWord(0).ToString("x8").ToUpper() + " 8=" + r8.readWord(0).ToString("x8").ToUpper() + " 9=" + r9.readWord(0).ToString("x8").ToUpper());
                Computer.Trace.WriteLine("      " + " 10=" + r10.readWord(0).ToString("x8").ToUpper() + " 11=" + r11.readWord(0).ToString("x8").ToUpper() + " 12=" + r12.readWord(0).ToString("x8").ToUpper() + " 13=" + r13.readWord(0).ToString("x8").ToUpper() + " 14=" + r14.readWord(0).ToString("x8").ToUpper());
            }
                addr += 4;
                r15.writeWord(0, Convert.ToUInt32(addr));

                
            }
            Computer.inT = false;
            stop = false;
            
           
            
          
            
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
                Instruction dcded = processor.decode(fetched);
                processor.exectute(dcded);
                
            }
            if (traceTest)
            {
                Computer.Trace.WriteLine(Computer.stepCounter.ToString().PadLeft(6, '0') + " " + r15.readWord(0).ToString("x8").ToUpper() + " " + Computer.HashSet() + " " + "0000" + " 0=" + r0.readWord(0).ToString("x8").ToUpper() + " 1=" + r1.readWord(0).ToString("x8").ToUpper() + " 2=" + r2.readWord(0).ToString("x8").ToUpper() + " 3=" + r3.readWord(0).ToString("x8").ToUpper());
                Computer.Trace.WriteLine("       " + " 4=" + r4.readWord(0).ToString("x8").ToUpper() + " 5=" + r5.readWord(0).ToString("x8").ToUpper() + " 6=" + r6.readWord(0).ToString("x8").ToUpper() + " 7=" + r7.readWord(0).ToString("x8").ToUpper() + " 8=" + r8.readWord(0).ToString("x8").ToUpper() + " 9=" + r9.readWord(0).ToString("x8").ToUpper());
                Computer.Trace.WriteLine("      " + " 10=" + r10.readWord(0).ToString("x8").ToUpper() + " 11=" + r11.readWord(0).ToString("x8").ToUpper() + " 12=" + r12.readWord(0).ToString("x8").ToUpper() + " 13=" + r13.readWord(0).ToString("x8").ToUpper() + " 14=" + r14.readWord(0).ToString("x8").ToUpper());
            }
            
            stop = false;
          


        }


    }//comp end

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
            uint fetche = Convert.ToUInt32(Computer.outerRam.readWord(Convert.ToInt32(address)));
            return fetche;
        }
        //decodes an instruction
        public Instruction decode(uint dcd)
        {
            Computer.log.WriteLine(Computer.stepCounter + " " + dcd);
            Instruction ist = new Instruction();
            //test bits 27 and 26;
            byte[] midStep = new byte[4];
            midStep = BitConverter.GetBytes(dcd);
            BitArray bity = new BitArray(midStep);
            bool t1 = bity[27];
            bool t2 = bity[26];
            bool t3 = bity[25];
            bool t4 = bity[24];

            if (t1 == false && t2 == false) // test flags
            {
                BitArray opcode = new BitArray(4);
                bool sflag = bity[11];
                bool iflag = bity[6];
                BitArray rd = new BitArray(4);
                BitArray shifter = new BitArray(12);
                BitArray sbz = new BitArray(4);

                sbz[0] = bity[19];
                sbz[1] = bity[18];
                sbz[2] = bity[17];
                sbz[3] = bity[16];

                opcode[0] = bity[24];
                opcode[1] = bity[23];
                opcode[2] = bity[22];
                opcode[3] = bity[21];

                rd[0] = bity[15];
                rd[1] = bity[14];
                rd[2] = bity[13];
                rd[3] = bity[12];

                for (int i = 0, p = 11; p > -1; i++, p--)
                {
                    shifter[i] = bity[p];
                }

                iflag = bity[25];
                sflag = bity[20];


                dataManip dp = new dataManip(dcd, opcode, sflag, iflag, rd, sbz, shifter);
                return dp;
            }
            if (t1 == true && t2 == true && t3 == true && t4 == true) // testing for swi May God have mercy
            {
                swi ender = new swi();
                return ender;
            }



            return ist;
        }

        //executes the instructions
        public bool exectute(Instruction inst)
        {
            if (inst is swi)
            {
                return false;
            }
            inst.run();
            if (!Computer.exec)
            {
                Thread.Sleep(250);
            }
            if (inst.instruct.readWord(0) == 0)
            {
                return false;
            }
            else
            {
                return true;
            }

        }
    }
   



    class Instruction
    {

       public Memory instruct = new Memory(4);
       public uint rd;
       public uint rm;
       public uint rn;
       public uint finalVal;
       public bool isIm;
       public uint opCode; 
       public bool weirdCase;
       public BitArray rShift; 
       public uint rs;//that one weird mul register

        public Instruction() { ;}

        public virtual void run() { }

        public uint barrelShift(BitArray shift, BitArray preIm)
        { // untested
           
            byte[] midstep = new byte[4];
            this.Reverse(ref shift);
            shift.CopyTo(midstep, 0);
 
            int sVal = BitConverter.ToInt32(midstep, 0);
            sVal = sVal * 2;
            byte[] midstep2 = new byte[4];
            this.Reverse(ref preIm);
            preIm.CopyTo(midstep2, 0);
            uint imNum = BitConverter.ToUInt32(midstep2, 0);
            uint finalVal = ((imNum >> sVal) | (imNum << (32 - sVal)));
            return finalVal;
        }

        public void Reverse(ref BitArray  array)
        {
            int length = array.Length;
            int mid = (length / 2);

            for (int i = 0; i < mid; i++)
            {
                bool bit = array[i];
                array[i] = array[length - i - 1];
                array[length - i - 1] = bit;
            }
        }
    }// end instruct parent 

    class dataManip : Instruction
    {


        public dataManip(uint dcd, BitArray op, bool sflag, bool iflag, BitArray rdm, BitArray sbz, BitArray shifter)
        {
            instruct.writeWord(0, dcd);
            base.rShift = shifter;
            byte[] stuffy = new byte[4];
            this.Reverse(ref op);
            op.CopyTo(stuffy, 0);
            base.opCode = BitConverter.ToUInt32(stuffy, 0);
            if (iflag)
            {
                base.isIm = true;
                BitArray shift = new BitArray(4);
                for (int x = 0; x < 4; x++)
                {
                    shift[x] = shifter[x];
                }
                BitArray preIm = new BitArray(8);
                for (int x = 4, y = 0; x < 12; x++, y++)
                {
                    preIm[y] = shifter[x];
                }
                byte[] sTest = new byte[4];
                base.finalVal = barrelShift(shift, preIm);
                this.Reverse(ref rdm);
                byte[] bite = new byte[1];
                rdm.CopyTo(bite, 0);
                byte[] conAttempt2 = new byte[4];
                conAttempt2[0] = bite[0];
                base.rd = BitConverter.ToUInt32(conAttempt2, 0);

                this.Reverse(ref sbz);
                byte[] sbstuff = new byte[4];
                sbz.CopyTo(sbstuff, 0);
                base.rn = BitConverter.ToUInt32(sbstuff, 0);
            }
            else
            {
                base.isIm = false;
                BitArray reg = new BitArray(4);
                // bit 4 and bit 7 checkin em
                if (shifter[4] && shifter[7])
                {
                    base.weirdCase = true;
                    BitArray rsl = new BitArray(4);
                    for (int x = 0; x < 4; x++)
                    {
                        rsl[x] = shifter[x];
                    }
                    byte[] rsC = new byte[4];
                    this.Reverse(ref rsl);
                    rsl.CopyTo(rsC, 0);
                    base.rs = BitConverter.ToUInt32(rsC, 0);
                }
                else
                {
                    base.weirdCase = false;
                }
                for (int x = 8, y = 0; x < 12; x++, y++)
                {
                    reg[y] = shifter[x];
                }
                this.Reverse(ref reg);
                byte[] newb = new byte[4];
                reg.CopyTo(newb, 0);
                base.rn = BitConverter.ToUInt32(newb, 0);

                this.Reverse(ref rdm);
                byte[] bite = new byte[1];
                rdm.CopyTo(bite, 0);
                byte[] conAttempt2 = new byte[4];
                conAttempt2[0] = bite[0];
                base.rd = BitConverter.ToUInt32(conAttempt2, 0);
                base.finalVal = BitConverter.ToUInt32(Computer.regRead(base.rd), 0);

                this.Reverse(ref sbz);
                byte[] m = new byte[4];
                sbz.CopyTo(m, 0);
                base.rm = BitConverter.ToUInt32(m, 0);





            }







        }

        public void shifter()
        {// non little endian
            bool b = base.rShift[7];
            bool t1 = base.rShift[5];
            bool t2 = base.rShift[6];
            uint shiftnum;
            uint rstuff  = BitConverter.ToUInt32(Computer.regRead(base.rn),0);
            bool ror = true;
            if (!base.rShift[0] && !base.rShift[4])
            {
                ror = true;
            }
            
           
            

            if (b)
            {
                //reg based
                BitArray rsl = new BitArray(4);
                for (int x = 0; x < 4; x++)
                {
                    rsl[x] = base.rShift[x];
                }
                byte[] rsC = new byte[4];
                base.Reverse(ref rsl);
                rsl.CopyTo(rsC, 0);
                uint r = BitConverter.ToUInt32(rsC, 0);
                shiftnum = BitConverter.ToUInt32( Computer.regRead(r),0);


            }
            else
            {// im based
                BitArray rsl = new BitArray(5);
                for (int x = 0; x < 5; x++)
                {
                    rsl[x] = base.rShift[x];
                }
                byte[] rsC = new byte[4];
                base.Reverse(ref rsl);
                rsl.CopyTo(rsC, 0);
                shiftnum = BitConverter.ToUInt32(rsC, 0);
            }
            long rst = Convert.ToInt64(rstuff);
            int shi = Convert.ToInt32(shiftnum);
            if (!t1 && !t2)//lsl
            {
                base.finalVal = (rstuff << shi);
            }
            if (!t1 && t2)//lsr
            {
                base.finalVal = (rstuff >> shi);
            }
            if (t1 && !t2)//asr
            {
                base.finalVal = (uint)((int)rstuff >> (int)shiftnum);
            }
            if (t1 && t2)//ror
            {
                if (ror)
                {
                    base.finalVal = ((rstuff >> shi) | (rstuff <<32- shi));
                }
                else
                {//num = (data >> 1) | (data << (32 - 1)); shiftedVal = (rM >> 1) | (rM << (32 - 1)); } //ROR Reg w/ Extend
                    base.finalVal =  (uint)((rst >> 1) | (rst << (32-1)));
                }


            }

        }

        public override void run()
        {
            base.run();

            uint regnum = base.rd;
            uint r1 = base.rm;
            uint r2 = base.rn;
            if (regnum == 15 || r1 == 15 || r2 == 15)
            {
                bool b = true;
                uint addr =BitConverter.ToUInt32(Computer.regRead(15),0);
                addr = addr + 8;
                Computer.regSet(15, addr);
            }
            
            if(!base.isIm){
              shifter();
            }
            
            



            if (base.opCode == 0xD) // mov
            {
               
                uint val = base.finalVal;
                Computer.regSet(regnum, val);
            }
            if (base.opCode == 0xF) // mvn
            {
                
                uint val = base.finalVal;
                val = ~val;
                Computer.regSet(regnum, val);
            }
            if (base.opCode == 0x4)// add
            {
                if (base.isIm)
                {
                    
                    
                    byte[] op1 = Computer.regRead(r1);
                    uint answer = BitConverter.ToUInt32(op1, 0) + base.finalVal;
                    Computer.regSet(regnum, answer);

                }
                else
                {
                    
                    
                    byte[] op1 = Computer.regRead(r1);
                    byte[] op2 = Computer.regRead(r2);
                    uint answer = BitConverter.ToUInt32(op1, 0) + base.finalVal;
                    Computer.regSet(regnum, answer);
                }
            }
            if (base.opCode == 0x2)// sub
            {
                if (base.isIm)
                {
                    
                    byte[] op1 = Computer.regRead(r2);
                    uint answer =  BitConverter.ToUInt32(op1, 0) - base.finalVal;
                    Computer.regSet(regnum, answer);
                }
                else
                {
                   
                    
                    byte[] op1 = Computer.regRead(r1);
                    byte[] op2 = Computer.regRead(r2);
                    uint answer = BitConverter.ToUInt32(op1, 0) - base.finalVal;
                    Computer.regSet(regnum, answer);
                }
            }
            if (base.opCode == 0x3) // rsb currently dependent on wether you did sub right. We got a smart kid right here
            {
                if (base.isIm)
                {
                   
                   
                    byte[] op1 = Computer.regRead(r2);
                    uint answer = base.finalVal - BitConverter.ToUInt32(op1, 0)  ;
                    Computer.regSet(regnum, answer);
                }
                else
                {
                  
                   
                    byte[] op1 = Computer.regRead(r1);
                    byte[] op2 = Computer.regRead(r2);
                    uint answer = BitConverter.ToUInt32(op2, 0) - base.finalVal;
                    Computer.regSet(regnum, answer);
                }
            }
            if (base.opCode == 0x0)//and + mul because of the 4/7 bit mumbo jumbo
            {
                if (base.isIm && !base.weirdCase)
                {
                    
                    
                    byte[] op1 = Computer.regRead(r1);
                    uint answer = (BitConverter.ToUInt32(op1, 0) & base.finalVal);
                    Computer.regSet(regnum, answer);
                }
                else if(!base.weirdCase)
                {
                    
                    
                    byte[] op1 = Computer.regRead(r1);
                    byte[] op2 = Computer.regRead(r2);
                    uint answer = (BitConverter.ToUInt32(op2, 0) & base.finalVal);
                    Computer.regSet(regnum, answer);
                }

                if (weirdCase) // mul
                {
                    
                    uint r1o = base.rn;
                    uint r2o = base.rs;
                    byte[] op1 = Computer.regRead(r1o);
                    byte[] op2 = Computer.regRead(r2o);
                    uint answer = (BitConverter.ToUInt32(op2, 0) * BitConverter.ToUInt32(op1, 0));
                    Computer.regSet(base.rm, answer);

                }
            }

            if (base.opCode == 0xC) // ORRRRRRR
            {

                if (base.isIm)
                {
                   
                    byte[] op1 = Computer.regRead(r1);
                    uint answer = (BitConverter.ToUInt32(op1, 0) | base.finalVal);
                    Computer.regSet(regnum, answer);
                }
                else
                {
                    
                    byte[] op1 = Computer.regRead(r1);
                    byte[] op2 = Computer.regRead(r2);
                    uint answer = (BitConverter.ToUInt32(op2, 0) | base.finalVal);
                    Computer.regSet(regnum, answer);
                }

            }

            if (base.opCode == 0x1) //EOR hehhehe EOR is sad 
            {
                if (base.isIm)
                {
                    
                    byte[] op1 = Computer.regRead(r1);
                    uint answer = (BitConverter.ToUInt32(op1, 0) ^ base.finalVal);
                    Computer.regSet(regnum, answer);
                }
                else
                {
                    
                    byte[] op1 = Computer.regRead(r1);
                    byte[] op2 = Computer.regRead(r2);
                    uint answer = (BitConverter.ToUInt32(op2, 0) ^ BitConverter.ToUInt32(op1, 0));
                    Computer.regSet(regnum, answer);
                }
            }

            if (base.opCode == 0xE) // BIC hahahahaha like the pens.
            {
                if (base.isIm)
                {
                    
                    byte[] op1 = Computer.regRead(r1);
                    uint answer = (BitConverter.ToUInt32(op1, 0) & (~base.finalVal));
                    Computer.regSet(regnum, answer);
                }
                else
                {
                   
                    byte[] op1 = Computer.regRead(r1);
                    byte[] op2 = Computer.regRead(r2);
                    uint answer = (BitConverter.ToUInt32(op2, 0) & (~base.finalVal));
                    Computer.regSet(regnum, answer);
                }
            }

        }
    }

    class swi : Instruction
    {
        public swi()
        {
            base.instruct.writeWord(0, 0);
        }


    }
    class dataMove : Instruction
    {

    }

    class branching : Instruction
    {

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
                Computer.setPcount((uint)elfHeader.e_entry);
                





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

                case "--exec":
                    Computer.exec = true;
                    break;

				default: 
					Computer.log.WriteLine ("you have entered an invalid command line. The current valid commands are --exec, --test, --mem [number], load [file] ");
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
                Instruction decoded = c.decode(0xe3a02030);
                bool eb = c.exectute(decoded);
                byte[] testBites = new byte[4];
                testBites = Computer.regRead(2);
                uint val = BitConverter.ToUInt32(testBites,0);
                Debug.Assert(48== val);
                Computer.regSet(2, 0);

                
                
			}

            if (Computer.exec == true)
            {
                Computer.run();
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
           // try
           // {
                options.parse(args);
           // }
           // catch
           // {
              //  Computer.log.Write("Prototype: Invalid input detected");
               // doIRun = false;
           // }
            
            if (doIRun && !Computer.exec)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Computer.sim = new SimGui();
                Application.Run(Computer.sim);
            }
            Computer.log.Close();
            Computer.Trace.Close();
		}
	}
}

