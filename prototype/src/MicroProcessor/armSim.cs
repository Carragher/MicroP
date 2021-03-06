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
        public static string path;
        public static bool N;
        public static bool Z;
        public static bool C;
        public static bool V;
        public static uint programCounterODoom;
        public static uint branchCount;
        public static bool bl;
        public static bool BX;
        public static bool stt;
        public static Queue<char> inQ;
        public static Queue<char> outQ;

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
            inQ = new Queue<char>();
            outQ = new Queue<char>();

            bl = true;
           
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
           Computer.readFile(Computer.path);
           byte[] b =BitConverter.GetBytes(outerRam.readWord(0));
           byte[] c = BitConverter.GetBytes(Computer.programCount);
           byte[] d = BitConverter.GetBytes(0x00007000);

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



        public static string flagToString()
        {
            //nzcv
            string pie = "";
            if (Computer.N == true)
            {
                pie += "1";

            }
            else
            {
                pie += "0";
            }

            if (Computer.Z == true)
            {
                pie += "1";
            }
            else
            {
                pie += "0";

            }

            if (Computer.C == true)
            {
                pie += "1";
            }
            else
            {
                pie += "0";
            }

            if (Computer.V == true)
            {
                pie += "1";
            }
            else
            {
                pie += "0";
            }

            return pie;
        }



        //Runs the fetch decode execute system in a loop
        public static void run()
        {
            Computer.inT = true;
            while (!stop)
            {
                if (Computer.stepCounter == 77)
                {
                    bool omega = true;
                }
                
                Computer.stepCounter += 1;
                Computer.log.WriteLine("Prototype: Running in a loop");
                int addr = Convert.ToInt32(r15.readWord(0));
                uint fetched = processor.fetch(r15.readWord(0));
               
                if (fetched == 0)
                {
                    break;
                }
                Instruction dcded = processor.decode(fetched);
                
                bool Failure = processor.exectute(dcded);
                
                uint localCount = 0;
                int logicBREAKER = 0;
                if (programCounterODoom == 0)
                {
                    localCount = Computer.r15.readWord(0);
                    logicBREAKER = 0;
                }
                else
                {
                    localCount = Computer.programCounterODoom ;

                    logicBREAKER = 0;

                    if (Computer.bl == false)
                    {
                        
                        logicBREAKER = 0;
                    }
                }
                r15.writeWord(0, Convert.ToUInt32(localCount));
                if (traceTest)
            {
                Computer.Trace.WriteLine(Computer.stepCounter.ToString().PadLeft(6, '0') + " " + Computer.r15.readWord(0).ToString("x8").ToUpper() + " " + "[sys]" + " " + Computer.flagToString() + " 0=" + r0.readWord(0).ToString("x8").ToUpper() + " 1=" + r1.readWord(0).ToString("x8").ToUpper() + " 2=" + r2.readWord(0).ToString("x8").ToUpper() + " 3=" + r3.readWord(0).ToString("x8").ToUpper());
                Computer.Trace.WriteLine("       " + " 4=" + r4.readWord(0).ToString("x8").ToUpper() + " 5=" + r5.readWord(0).ToString("x8").ToUpper() + " 6=" + r6.readWord(0).ToString("x8").ToUpper() + " 7=" + r7.readWord(0).ToString("x8").ToUpper() + " 8=" + r8.readWord(0).ToString("x8").ToUpper() + " 9=" + r9.readWord(0).ToString("x8").ToUpper());
                Computer.Trace.WriteLine("      " + " 10=" + r10.readWord(0).ToString("x8").ToUpper() + " 11=" + r11.readWord(0).ToString("x8").ToUpper() + " 12=" + r12.readWord(0).ToString("x8").ToUpper() + " 13=" + r13.readWord(0).ToString("x8").ToUpper() + " 14=" + r14.readWord(0).ToString("x8").ToUpper());
                Computer.Trace.Flush();
                }
              
                localCount += 4;
                r15.writeWord(0, Convert.ToUInt32(localCount));
                if (programCounterODoom != 0) // if last instruct was branch command  set program to non hardcode
                {
                    r15.writeWord(0, Convert.ToUInt32(branchCount +4));
                }
                Computer.programCounterODoom = 0;
                
                Computer.bl = true;

                
            }
            Computer.inT = false;
            stop = false;



            /*
             * 
             * Computer.Trace.WriteLine(Computer.stepCounter.ToString().PadLeft(6, '0') + " " + r15.readWord(0).ToString("x8").ToUpper() + " " + Computer.HashSet() + " " + "0000" + " 0=" + r0.readWord(0).ToString("x8").ToUpper() + " 1=" + r1.readWord(0).ToString("x8").ToUpper() + " 2=" + r2.readWord(0).ToString("x8").ToUpper() + " 3=" + r3.readWord(0).ToString("x8").ToUpper());
                  Computer.Trace.WriteLine("       " + " 4=" + r4.readWord(0).ToString("x8").ToUpper() + " 5=" + r5.readWord(0).ToString("x8").ToUpper() + " 6=" + r6.readWord(0).ToString("x8").ToUpper() + " 7=" + r7.readWord(0).ToString("x8").ToUpper() + " 8=" + r8.readWord(0).ToString("x8").ToUpper() + " 9=" + r9.readWord(0).ToString("x8").ToUpper());
                  Computer.Trace.WriteLine("      " + " 10=" + r10.readWord(0).ToString("x8").ToUpper() + " 11=" + r11.readWord(0).ToString("x8").ToUpper() + " 12=" + r12.readWord(0).ToString("x8").ToUpper() + " 13=" + r13.readWord(0).ToString("x8").ToUpper() + " 14=" + r14.readWord(0).ToString("x8").ToUpper());
                  Computer.Trace.Flush();
             * 
             * */

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

            if (Computer.stepCounter == 10)
            {
                bool omega = true;
            }

            Computer.stepCounter += 1;
            Computer.log.WriteLine("Prototype: Running in a loop");
            int addr = Convert.ToInt32(r15.readWord(0));
            uint fetched = processor.fetch(r15.readWord(0));

            
            Instruction dcded = processor.decode(fetched);

            processor.exectute(dcded);
            uint localCount = 0;
            uint logicBREAKER = 0;
            if (programCounterODoom == 0)
            {
                localCount = Computer.r15.readWord(0);
                logicBREAKER = 0;
            }
            else
            {
                localCount = Computer.programCounterODoom;


                logicBREAKER = 0;
            }
            r15.writeWord(0, Convert.ToUInt32(localCount));
            if (traceTest)
            {
                Computer.Trace.WriteLine(Computer.stepCounter.ToString().PadLeft(6, '0') + " " + Computer.r15.readWord(0).ToString("x8").ToUpper() + " " + "[sys]" + " " + Computer.flagToString() + " 0=" + r0.readWord(0).ToString("x8").ToUpper() + " 1=" + r1.readWord(0).ToString("x8").ToUpper() + " 2=" + r2.readWord(0).ToString("x8").ToUpper() + " 3=" + r3.readWord(0).ToString("x8").ToUpper());
                Computer.Trace.WriteLine("       " + " 4=" + r4.readWord(0).ToString("x8").ToUpper() + " 5=" + r5.readWord(0).ToString("x8").ToUpper() + " 6=" + r6.readWord(0).ToString("x8").ToUpper() + " 7=" + r7.readWord(0).ToString("x8").ToUpper() + " 8=" + r8.readWord(0).ToString("x8").ToUpper() + " 9=" + r9.readWord(0).ToString("x8").ToUpper());
                Computer.Trace.WriteLine("      " + " 10=" + r10.readWord(0).ToString("x8").ToUpper() + " 11=" + r11.readWord(0).ToString("x8").ToUpper() + " 12=" + r12.readWord(0).ToString("x8").ToUpper() + " 13=" + r13.readWord(0).ToString("x8").ToUpper() + " 14=" + r14.readWord(0).ToString("x8").ToUpper());
                Computer.Trace.Flush();
            }
            localCount += 4;
            r15.writeWord(0, Convert.ToUInt32(localCount + logicBREAKER));
            

            Computer.programCounterODoom = 0;
            Computer.inT = false;
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

        public bool checkCond(int Cond)
        {
            bool N = Computer.N;
            bool Z = Computer.Z;
            bool C = Computer.C;
            bool F = Computer.V;

            switch (Cond)
            {
                case 0x0:
                    if (Z) { return true; }
                    break;
                case 0x1:
                    if (!Z) {
                        return true; }
                    break;
                case 0x2:
                    if (C) { return true; }
                    break;
                case 0x3:
                    if (!C) { return true; }
                    break;
                case 0x4:
                    if (N) { return true; }
                    break;
                case 0x5:
                    if (!N) { return true; }
                    break;
                case 0x6:
                    if (F) { return true; }
                    break;
                case 0x7:
                    if (!F) { return true; }
                    break;
                case 0x8:
                    if ((C && !Z)) { return true; }
                    break;
                case 0x9:
                    if ((!C || Z)) { return true; }
                    break;
                case 0xa:
                    if ((N == F)) { return true; }
                    break;
                case 0xb:
                    if ((N != F)) { return true; }
                    break;
                case 0xc:
                    if ((!Z && N == F)) { return true; }
                    break;
                case 0xd:
                    if ((Z || N != F)) { return true; }
                    break;
                case 0xe:
                    return true;
                    break;
                case 0xf:
                    return false;
                    break;
                default:
                    return false;
                    break;
            }
            return false;
            
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
            Computer.BX = false;
            Computer.log.WriteLine(Computer.stepCounter + " " + dcd);
            Instruction ist = new Instruction();
            //test bits 27 and 26;
            byte[] midStep = new byte[4];
            midStep = BitConverter.GetBytes(dcd);
            BitArray bity = new BitArray(midStep);
            BitArray mixup = new BitArray(4);
            mixup[3] = bity[28];
            mixup[2] = bity[29];
            mixup[1] = bity[30];
            mixup[0] = bity[31];
            byte[] converter = new byte[4];
            ist.Reverse(ref mixup);
            
            
            mixup.CopyTo(converter, 0);
            int havntSlept = BitConverter.ToInt32(converter, 0);


            bool testMe =checkCond( havntSlept);
            if (!testMe)
            {
               return ist;
            } 
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
                BitArray specialCase1 = new BitArray(8);
                BitArray specialCase2 = new BitArray(4);

                for (int x = 27, y = 7; x >= 20; x--, y--)
                {
                    specialCase1[y] = bity[x];
                }
                for (int x = 3, y = 7; x >= 0; x-- ,y--)
                {
                    specialCase2[x] = bity[y];
                }
                byte[] sp1 = new byte[4];
                byte[] sp2 = new byte[4];
               
                specialCase1.CopyTo(sp1, 0);
                specialCase2.CopyTo(sp2, 0);
                uint pie1 = BitConverter.ToUInt32(sp1, 0);
                uint pie2 = BitConverter.ToUInt32(sp2, 0);
                

                if (pie1 == 18 && pie2 == 1)/// magic BX case that is of evil things
                {
                    ///r15 now = memory.readword(rm) + (pc offset)
                    Computer.BX = true;
                    
                    sBranch bx = new sBranch(bity);
                    return bx;

                }


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

            if (t1 == false && t2 == true) // load store stuff
            {
                //dcd, opcode, p,u,b,w,l,rd,rn,shifter
                BitArray opcode = new BitArray(4);
                bool im = bity[25];
                bool p = bity[24];
                bool u = bity[23];
                bool b = bity[22];
                bool w = bity[21];
                bool l = bity[20];
                BitArray rn = new BitArray(4);
                BitArray rd = new BitArray(4);
                BitArray shifter = new BitArray(12);

                for (int i = 0, pb = 11; pb > -1; i++, pb--)
                {
                    shifter[i] = bity[pb];
                }

                opcode[0] = bity[24];
                opcode[1] = bity[23];
                opcode[2] = bity[22];
                opcode[3] = bity[21];

                rd[0] = bity[15];
                rd[1] = bity[14];
                rd[2] = bity[13];
                rd[3] = bity[12];

                rn[0] = bity[19];
                rn[1] = bity[18];
                rn[2] = bity[17];
                rn[3] = bity[16];

                //uint dcd, BitArray op, bool Im, bool pi, bool ui, bool bi, bool wi, bool li, BitArray rd, BitArray rn, BitArray shifter
                dataMove dm = new dataMove(dcd, opcode, im, p, u, b, w, l, rd, rn, shifter);
                return dm;


            }

            if (t1 == true && t2 == false && t3 == false ) // LOAD STORE MULTIPLES uint dcd, bool pi, bool ui, bool bi, bool wi, bool li, BitArray rn, BitArray btmHalf
            {
                bool p = bity[24];
                bool u = bity[23];
                bool b = bity[22];
                bool w = bity[21];
                bool l = bity[20];
                BitArray rn = new BitArray(4);
                BitArray btm = new BitArray(16);

                rn[0] = bity[19];
                rn[1] = bity[18];
                rn[2] = bity[17];
                rn[3] = bity[16];

                for (int x = 15; x >= 0; x--)
                {
                    btm[x] = bity[x];
                }
                mulData mD = new mulData(dcd, p, u, b, w, l, rn, btm);
                return mD;


            }

            if (t1 == true && t2 == false && t3 == true) //  branching
            {

                //t4 is L for b and bl
                bool bi = bity[24];
                BitArray btm = new BitArray(24);

                byte[] midStep1 = new byte[4];

                midStep1 = BitConverter.GetBytes(dcd);

                BitArray bity1 = new BitArray(midStep1);

                for (int x = 23; x >= 0; x--)
                {
                    btm[x] = bity1[x];
                }
                byte[] lol = new byte[4];
                btm.CopyTo(lol, 0);

                branching branchie = new branching(dcd, bi, btm);
                return branchie;



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
                Computer.stop = true;
                return false;

            }
            inst.run();
            if (!Computer.exec)
            {
                
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

        public virtual void run()
        {
            if (!Computer.BX)
            {
                if (rd == 15 || rm == 15 || rn == 15)
                {
                    bool b = true;
                    uint addr = BitConverter.ToUInt32(Computer.regRead(15), 0);
                    addr = addr + 8;
                    Computer.regSet(15, addr);
                }
            }
        }

        public void shifter()
        {// non little endian
            bool b = rShift[7];
            bool t1 = rShift[5];
            bool t2 = rShift[6];
            uint shiftnum;
            uint rstuff = BitConverter.ToUInt32(Computer.regRead(rn), 0);
            bool ror = true;
            if (!rShift[0] && !rShift[4])
            {
                ror = true;
            }




            if (b)
            {
                //reg based
                BitArray rsl = new BitArray(4);
                for (int x = 0; x < 4; x++)
                {
                    rsl[x] = rShift[x];
                }
                byte[] rsC = new byte[4];
                Reverse(ref rsl);
                rsl.CopyTo(rsC, 0);
                uint r = BitConverter.ToUInt32(rsC, 0);
                shiftnum = BitConverter.ToUInt32(Computer.regRead(r), 0);


            }
            else
            {// im based
                BitArray rsl = new BitArray(5);
                for (int x = 0; x < 5; x++)
                {
                    rsl[x] = rShift[x];
                }
                byte[] rsC = new byte[4];
                Reverse(ref rsl);
                rsl.CopyTo(rsC, 0);
                shiftnum = BitConverter.ToUInt32(rsC, 0);
            }
            long rst = Convert.ToInt64(rstuff);
            int shi = Convert.ToInt32(shiftnum);
            if (!t1 && !t2)//lsl
            {
                finalVal = (rstuff << shi);
            }
            if (!t1 && t2)//lsr
            {
                finalVal = (rstuff >> shi);
            }
            if (t1 && !t2)//asr
            {
                finalVal = (uint)((int)rstuff >> (int)shiftnum);
            }
            if (t1 && t2)//ror
            {
                if (ror)
                {
                    finalVal = ((rstuff >> shi) | (rstuff << 32 - shi));
                }
                else
                {//num = (data >> 1) | (data << (32 - 1)); shiftedVal = (rM >> 1) | (rM << (32 - 1)); } //ROR Reg w/ Extend
                    finalVal = (uint)((rst >> 1) | (rst << (32 - 1)));
                }


            }

        }

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

    class sBranch : Instruction
    {
        public BitArray bity;
        public sBranch(BitArray bit)
        {
            this.bity = bit;
        }

        public override void run()
        {
            base.run();

            Computer.programCounterODoom = Computer.r15.readWord(0);

            byte[] blah = new byte[4];
            BitArray newb = new BitArray(4);
            newb[0] = bity[0];
            newb[1] = bity[1];
            newb[2] = bity[2];
            newb[3] = bity[3];

            this.Reverse(ref bity);
            newb.CopyTo(blah, 0);
            int oops = BitConverter.ToInt32(blah, 0);

            
            byte[] converter = Computer.regRead(BitConverter.ToUInt32(blah, 0));
            uint pie = BitConverter.ToUInt32(converter, 0);
            Computer.branchCount = BitConverter.ToUInt32(converter, 0) - 4;

            Computer.r15.writeWord(0, Computer.outerRam.readWord(BitConverter.ToInt32(blah,0)));
            
        }
    }
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



        public override void run()
        {

            base.run();

            uint regnum = base.rd;
            uint r1 = base.rm;
            uint r2 = base.rn;
            
            
            if(!base.isIm){
              shifter();
            }


            if (base.opCode == 0xA)//cmp
            {
                
                
                byte[] op1 = Computer.regRead(r1);
                uint num1 = BitConverter.ToUInt32(op1, 0);
                uint num2 = base.finalVal;
                int answer = (int)(num1 - num2);
                byte[] Conversion = new byte[4];
                Conversion = BitConverter.GetBytes(answer);
                BitArray TestBits = new BitArray(Conversion);
                bool N = TestBits[31];
                Computer.N = N;// get n flag

                if (answer == 0)
                {
                    Computer.Z = true;
                }
                else
                {
                    Computer.Z = false;
                } //#mr COCO

                //c flag unsigned thingie

                if (num2 > num1)
                {

                    Computer.C = false;

                }
                else
                {

                    Computer.C = true;

                }



                // v flag signed thingie ma jig
                answer = (int)num1 - (int)num2; // black magic flip sign if it dont work
                if (((int)num1 > -1 && (int)num2 < 0 && answer < 0)|| ((int)num1 < 0 && (int)num2 >-1 && answer > -1)) 
                {
                    Computer.V = true;
                } else {
                    Computer.V = false;
                }





                    


                    


              

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
                    
                    
                    byte[] op1 = Computer.regRead(r2);
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

        public bool p;
        public bool u;
        public bool b;
        public bool w;
        public bool l;
        public uint addr;
        public bool scal;


 


        public dataMove(uint dcd, BitArray op, bool Im, bool pi, bool ui, bool bi, bool wi, bool li, BitArray rd, BitArray rn, BitArray shifter)
        {
            instruct.writeWord(0, dcd);
            base.rShift = shifter;
            byte[] opStuff =  new byte[4];
            this.Reverse(ref op);
            op.CopyTo(opStuff, 0);
            base.opCode = BitConverter.ToUInt32(opStuff, 0);
            this.p = pi;
            this.u = ui;
            this.b = bi;
            this.w = wi;
            this.l = li;
            base.isIm = Im;
            this.scal = false;

            BitArray BUGFIXER = new BitArray(4);

            for (int x = 0; x < 4; x++)
            {
                BUGFIXER[x] = shifter[7 + x];
            }

            byte[] BLARG = new byte[4];
            
            BUGFIXER.CopyTo(BLARG, 0);
            base.rm = BitConverter.ToUInt32(BLARG, 0);

            byte[] midstep = new byte[4];
            this.Reverse(ref rd);
            rd.CopyTo(midstep, 0);
            base.rd = BitConverter.ToUInt32(midstep, 0);

            byte[] midstep2 = new byte[4];
            this.Reverse(ref rn);
            rn.CopyTo(midstep2, 0);
            base.rn = BitConverter.ToUInt32(midstep2, 0);

        }

        public override void run()
        {
            base.run();


            
            if (!base.isIm)
            {
                // p=0 addr = rn
                // p = addr = rn + operand 2
                //u 1 pos
                //if p and w is set then you write back to rn 


                if (this.l) // LOAD
                {
                    
                    if (this.p)
                    {
                        byte[] midstep = new byte[4]; // ya done messed up now
                        this.Reverse(ref this.rShift);
                        this.rShift.CopyTo(midstep, 0);


                        int op2 = BitConverter.ToInt32(midstep,0);
                        if (!this.u)
                        {
                            op2 = op2 * -1;
                        }
                        
                        this.addr = BitConverter.ToUInt32(Computer.regRead(base.rn),0);
                        this.addr = Convert.ToUInt32(addr + op2);
                        if (this.rn == 15 || this.rd == 15)
                        {
                            this.addr += 8;
                        }
                        if (this.b) // byte
                        {
                            byte writeMe  =Computer.outerRam.readByte((int)addr);
                            Computer.regSet(this.rd, Convert.ToUInt32(writeMe));


                        }
                        else // word 
                        {
                            uint writer = Computer.outerRam.readWord((int)addr);
                            Computer.regSet(this.rd, writer);

                        }
                        if (this.p && this.w)
                        {
                            Computer.regSet(rn, addr);
                        }

                    }
                    else
                    {

                        this.addr = BitConverter.ToUInt32(Computer.regRead(base.rn),0);
                        if (this.rn == 15 || this.rd == 15)
                        {
                            this.addr += 8;
                        }
                        if (this.b) // byte
                        {
                            byte writeMe  =Computer.outerRam.readByte((int)addr);
                            Computer.regSet(this.rd, Convert.ToUInt32(writeMe));


                        }
                        else // word 
                        {
                            uint writer = Computer.outerRam.readWord((int)addr);
                            Computer.regSet(this.rd, writer);

                        }

                    }



                }
                else // STORE
                {


                    if (this.p)
                    {
                        byte[] midstep = new byte[4];
                        this.Reverse(ref this.rShift);
                        this.rShift.CopyTo(midstep, 0);


                        int op2 = BitConverter.ToInt32(midstep, 0);
                        if (!this.u)
                        {
                            op2 = op2 * -1;
                        }
                        this.addr = BitConverter.ToUInt32(Computer.regRead(base.rn), 0);
                        this.addr = Convert.ToUInt32(addr + op2);
                        if (this.rn == 15 || this.rd == 15)
                        {
                            this.addr += 8;
                        }
                        if (this.b) // byte
                        {
                            byte[] writeMe = Computer.regRead(rd);
                            Computer.outerRam.writeByte((int)addr, writeMe[0]);


                        }
                        else // word 
                        {
                            byte[] writeme = Computer.regRead(rd);
                            Computer.outerRam.writeWord((int)addr, BitConverter.ToUInt32(writeme, 0));


                        }
                        if (this.p && this.w)
                        {
                            Computer.regSet(rn, addr);
                        }

                    }
                    else
                    {

                        this.addr = BitConverter.ToUInt32(Computer.regRead(base.rn), 0);
                        if (this.rn == 15 || this.rd == 15)
                        {
                            this.addr += 8;
                        }
                        if (this.b) // byte
                        {
                            byte[] writeMe = Computer.regRead(rd);
                            Computer.outerRam.writeByte((int)addr, writeMe[3]);


                        }
                        else // word 
                        {
                            
                            byte[] writeme = Computer.regRead(rd);
                            BitArray pie = new BitArray(writeme);
                            this.Reverse(ref pie);
                            pie.CopyTo(writeme, 0);
                            uint superPie = BitConverter.ToUInt32(writeme, 0);
                            Computer.outerRam.writeWord((int)addr, superPie);


                        }

                    }

                }


            }
            else // REG HALF OF LOAD AND STORE
            {





                uint save = this.rn;
                this.rn = this.rm;
                this.shifter();
                this.rn = save;
                if (this.l) // LOAD
                {
                    if (this.p)
                    {
                        
                        int op2 = Convert.ToInt32(base.finalVal);
                            if (!this.u)
                            {
                                op2 = op2 * -1;
                            }
                        this.addr = BitConverter.ToUInt32(Computer.regRead(base.rn), 0);
                        this.addr = Convert.ToUInt32(addr + op2);
                        if (this.b) // byte
                        {
                            byte writeMe = Computer.outerRam.readByte((int)addr);
                            Computer.regSet(this.rd, Convert.ToUInt32(writeMe));


                        }
                        else // word 
                        {
                            uint writer = Computer.outerRam.readWord((int)addr);
                            Computer.regSet(this.rd, writer);

                        }
                        if (this.p && this.w)
                        {
                            Computer.regSet(rn, addr);
                        }

                    }
                    else
                    {

                        this.addr = BitConverter.ToUInt32(Computer.regRead(base.rn), 0);
                        if (this.b) // byte
                        {
                            byte writeMe = Computer.outerRam.readByte((int)addr);
                            Computer.regSet(this.rd, Convert.ToUInt32(writeMe));


                        }
                        else // word 
                        {
                            uint writer = Computer.outerRam.readWord((int)addr);
                            Computer.regSet(this.rd, writer);

                        }

                    }



                }
                else // STORE
                {


                    if (this.p)
                    {
                        int op2 = Convert.ToInt32(base.finalVal);
                        if (!this.u)
                        {
                            op2 = op2 * -1;
                        }
                        this.addr = BitConverter.ToUInt32(Computer.regRead(base.rn), 0);
                        this.addr = Convert.ToUInt32(addr + op2);
                        if (this.b) // byte
                        {
                            byte[] writeMe = Computer.regRead(rd);
                            BitArray pie =  new BitArray(writeMe);
                            this.Reverse(ref pie);

                            Computer.outerRam.writeByte((int)addr, writeMe[0]);


                        }
                        else // word 
                        {
                            byte[] writeme = Computer.regRead(rd);
                            BitArray pie = new BitArray(writeme);
                            
                            pie.CopyTo(writeme,0);

                            
                            Computer.outerRam.writeWord((int)addr, BitConverter.ToUInt32(writeme, 0));


                        }
                        if (this.p && this.w)
                        {
                            Computer.regSet(rn, addr);
                        }

                    }
                    else
                    {

                        this.addr = BitConverter.ToUInt32(Computer.regRead(base.rn), 0);
                        if (this.b) // byte
                        {
                            byte[] writeMe = Computer.regRead(rd);
                            Computer.outerRam.writeByte((int)addr, writeMe[3]);


                        }
                        else // word 
                        {
                            byte[] writeme = Computer.regRead(rd);
                            BitArray pie = new BitArray(writeme);
                            this.Reverse(ref pie);
                            pie.CopyTo(writeme,0);
                            uint superPie = BitConverter.ToUInt32(writeme, 0);
                            Computer.outerRam.writeWord((int)addr, superPie);


                        }

                    }

                }


            }

        }
    }



    class mulData : Instruction
    {
        public bool p;
        public bool u;
        public bool b;
        public bool w;
        public bool l;
        public uint addr;
        public uint regCount;
        public BitArray Breg;
        



        public mulData(uint dcd, bool pi, bool ui, bool bi, bool wi, bool li, BitArray rn, BitArray btmHalf)
        {
            this.p = pi;
            this.u = ui;
            this.b = bi;
            this.w = wi;
            this.l = li;
            this.regCount = 0;
            this.Breg = btmHalf;
            byte[] midstep2 = new byte[4];
            this.Reverse(ref rn);
            rn.CopyTo(midstep2, 0);
            base.rn = BitConverter.ToUInt32(midstep2, 0);

            for (int x = 0; x < 16; x++)
            {
                if (btmHalf[x] == true)
                {
                    regCount++;
                }
            }
            


        }

        public override void run()
        {
            base.run();
            bool incAfter = false ;
            bool decBefore = false;
            uint lp = 4 * regCount;
            if (this.p)
            {
                decBefore = true;
                //Computer.regSet(13, BitConverter.ToUInt32(Computer.regRead(13), 0) - lp);
            }

            if (!this.p)
            {
                incAfter = true;
                //Computer.regSet(13, BitConverter.ToUInt32(Computer.regRead(13), 0) + lp);
            }
            
            

            this.addr = BitConverter.ToUInt32(Computer.regRead(base.rn), 0);

            if (this.l)//LOADS 
            {

                if (decBefore)
                {
                    addr = addr;
                    for (int x = 0; x < 16; x++)
                    {
                        if (this.Breg[x])
                        {
                            Computer.regSet((uint)x, Computer.outerRam.readWord((int)addr));
                            addr +=4;
                        }
                    }
                }
                if (incAfter)
                {
                    addr = addr;
                    for (int x = 0; x < 16; x++)
                    {
                        if (this.Breg[x])
                        {
                            Computer.regSet((uint)x, Computer.outerRam.readWord((int)addr));
                            addr +=4;
                        }
                    }
                }
                

                
            }
            else// STORE 
            {

                if (decBefore)
                {
                     addr = addr - (regCount * 4);
                    for (int x = 0; x < 16; x++)
                    {
                        if (this.Breg[x])
                        {

                            Computer.outerRam.writeWord((int)addr,BitConverter.ToUInt32(Computer.regRead((uint)x),0));
                            addr +=4;
                        }
                    }
                }
                if (incAfter)
                {
                    addr = addr + (regCount * 4);
                    for (int x = 0; x < 16; x++)
                    {
                        if (this.Breg[x])
                        {
                            Computer.outerRam.writeWord((int)addr, BitConverter.ToUInt32(Computer.regRead((uint)x), 0));
                            addr += 4;
                        }
                    }
                }


            }
            if (this.w && this.p)
            {
                Computer.regSet(this.rn,addr - lp );
            }
            if (this.w && !this.p)
            {
                Computer.regSet(this.rn, addr );
            }
         
        }

    }

    class branching : Instruction
    {
        public uint dcd;
        public bool b;
        public BitArray btm;
        public uint address;
        



        public branching(uint dcd, bool bi, BitArray btm)
        {
            // TODO: Complete member initialization
            this.dcd = dcd;
            this.b = bi;
            this.btm = btm;

            bool sign = btm[23];
            byte[] midstep = new byte[4];
            btm.CopyTo(midstep,0);
            this.address = BitConverter.ToUInt32(midstep, 0);
            this.address &= 0x00FFFFFF;

            if(sign){
                address |= 0x3F000000;
            }

            this.address = (this.address << 2);
        }

        public override void run()
        {
            
            
            uint baseaddr = BitConverter.ToUInt32(Computer.regRead(15),0);
            uint addrB = 0;
            Computer.programCounterODoom = Computer.r15.readWord(0);
            if (b)
            {
                Computer.regSet(14, baseaddr+4);
                Computer.bl = false;
            }

            addrB = Computer.programCounterODoom + this.address + 4;
            Computer.branchCount = addrB;
          
            

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
        public uint flags;

        public Memory() { ;}

		//instructer that takes a uInt variable and intializes the size of ram with it.
		public Memory(uint size){
			RAM = new byte[size];
            flags = 0;
		}

        public uint returnFlags()
        {
            return this.flags;
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
            if (address == 0x00100000)
            {
                //read from que ya dummy
            }
            else
            {
                return RAM[address];
            }

			
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
                Computer.path = file;
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
            Computer.Trace.AutoFlush = true;
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

