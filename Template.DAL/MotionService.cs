using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EasyModbus;
using Template.Models;
using Utils;

namespace Template.DAL
{
    public class MotionService {

        /// <summary>IP地址</summary>
        public string IP { get; set; }
        /// <summary>端口</summary>
        public int Port { get; set; }
        /// <summary>是否连接成功</summary>
        public bool IsConnected => client?.Connected ?? false;

        /// <summary>X轴</summary>
        public AxisInfo XAxis { get; set; }
        /// <summary>Y轴</summary>
        public AxisInfo YAxis { get; set; }
        /// <summary>Z轴</summary>
        public AxisInfo ZAxis { get; set; }

        /// <summary>定长移动距离</summary>
        public double Distence { get; set; }

        /// <summary>点动速度</summary>
        public double JogSpeed { get; set; }

        public bool AllPosDone { get { return XAxis.Done && YAxis.Done && ZAxis.Done; } }

        public AxisPoint CurrentPostion {
            get {
                return new AxisPoint() {
                    XAxisPostion = XAxis.CurrentPostion,
                    YAxisPostion = YAxis.CurrentPostion,
                    ZAxisPostion = ZAxis.CurrentPostion
                };
            }
        }

        /// <summary>线圈写入暂存队列</summary>
        public ConcurrentQueue<WriteBool> WriteBoolData{get;set;}
        /// <summary>保持寄存器写入暂存队列</summary>
        public ConcurrentQueue<WriteDouble> WriteDoubleData { get; set; }

        /// <summary>用于暂存读取回来的输入线圈值</summary>
        private bool[] area1_bool;

        public CancellationTokenSource cancelSource;
        /// <summary>用于持续读取的线程</summary>
        private Thread thread;

        private ModbusClient client;

        private object _async=new object();
        public MotionService(string iP, int port) {
            IP = iP;
            Port = port;
            client = new ModbusClient(IP, Port);

            cancelSource = new CancellationTokenSource();
            thread = new Thread(Communication);
            thread.IsBackground = true;
            cancelSource.Token.Register(() => { Console.WriteLine("取消了线程"); });

            #region 初始化写入数据队列及数据

            WriteBoolData = new ConcurrentQueue<WriteBool>();
            WriteDoubleData = new ConcurrentQueue<WriteDouble>();
            XAxis = new AxisInfo() { ID=1};
            YAxis = new AxisInfo() { ID=2};
            ZAxis = new AxisInfo() { ID=3};
            #endregion

            

        }

        public void Run() {
            thread.Start();
        }
        /// <summary>通讯方法</summary>
        private void Communication() {
            while (!cancelSource.IsCancellationRequested) {
                try {
                    if (!IsConnected) {
                        Connect();
                        if (!IsConnected) {
                            continue;
                        }
                    }
                    else {
                        ReadAnalyArea1();
                        Thread.Sleep(50);
                        ReadAnalyArea3();
                        Thread.Sleep(50);
                        ReadAnalyArea4();
                        Thread.Sleep(50);
                    }
                }
                catch (Exception ex) {
                    Utils.LogHelper.LogError(ex);
                }
            }
        }

        /// <summary>断开连接</summary>
        private void DisConnect() {
            if (client != null) {
                client.Disconnect();
            }
        }
        /// <summary>连接</summary>
        private void Connect() {
            client.Disconnect();
            client.Connect();
        }

        /// <summary>读取并解析数据</summary>
        /// <remark>写优先，当写队列中有数据时，处理完当前通讯之后立即处理写通讯，执行完再返回来执行读通讯</remark>
        private void ReadAndWriteData() {
           // area0_bool = client.ReadCoils(0, 12);
            
            
           // area4_int = client.ReadHoldingRegisters(0, 20);
        }
        /// <summary>
        /// 读取一区数据并赋值
        /// </summary>
        private void ReadAnalyArea1() {
            try {
                lock (_async) {
                    area1_bool = client.ReadDiscreteInputs(0, 18);
                }
                XAxis.Enable = area1_bool[0];
                XAxis.Error = area1_bool[1];
                XAxis.Homed = area1_bool[2];
                XAxis.Done = area1_bool[3];
                XAxis.MaxLimited = area1_bool[4];
                XAxis.MinLimited = area1_bool[5];

                YAxis.Enable = area1_bool[6];
                YAxis.Error = area1_bool[7];
                YAxis.Homed = area1_bool[8];
                YAxis.Done = area1_bool[9];
                YAxis.MaxLimited = area1_bool[10];
                YAxis.MinLimited = area1_bool[11];

                ZAxis.Enable = area1_bool[12];
                ZAxis.Error = area1_bool[13];
                ZAxis.Homed = area1_bool[14];
                ZAxis.Done = area1_bool[15];
                ZAxis.MaxLimited = area1_bool[16];
                ZAxis.MinLimited = area1_bool[17];
            }
            catch (Exception ex) {

                LogHelper.LogError(ex);
            }
            
        }

        private void ReadAnalyArea3() {
            try {
                lock (_async) {
                    List<int> templist = client.ReadInputRegisters(0, 30).ToList<int>();



                    XAxis.CurrentSpeed = ModbusClient.ConvertRegistersToDouble(templist.Skip<int>(0).Take<int>(4).ToArray<int>(),
                        ModbusClient.RegisterOrder.HighLow);
                    XAxis.CurrentPostion = ModbusClient.ConvertRegistersToDouble(templist.Skip<int>(4).Take<int>(4).ToArray<int>(),
                        ModbusClient.RegisterOrder.HighLow);

                    YAxis.CurrentSpeed = ModbusClient.ConvertRegistersToDouble(templist.Skip<int>(8).Take<int>(4).ToArray<int>(),
                         ModbusClient.RegisterOrder.HighLow);
                    YAxis.CurrentPostion = ModbusClient.ConvertRegistersToDouble(templist.Skip<int>(12).Take<int>(4).ToArray<int>(),
                        ModbusClient.RegisterOrder.HighLow);

                    ZAxis.CurrentSpeed = ModbusClient.ConvertRegistersToDouble(templist.Skip<int>(16).Take<int>(4).ToArray<int>(),
                       ModbusClient.RegisterOrder.HighLow);
                    ZAxis.CurrentPostion = ModbusClient.ConvertRegistersToDouble(templist.Skip<int>(20).Take<int>(4).ToArray<int>(),
                        ModbusClient.RegisterOrder.HighLow);

                    XAxis.ErrorId = Convert.ToUInt32(ModbusClient.ConvertRegistersToInt(templist.Skip(24).Take(2).ToArray(),
                        ModbusClient.RegisterOrder.HighLow));
                    YAxis.ErrorId = Convert.ToUInt32(ModbusClient.ConvertRegistersToInt(templist.Skip(26).Take(2).ToArray(),
                        ModbusClient.RegisterOrder.HighLow));
                    ZAxis.ErrorId = Convert.ToUInt32(ModbusClient.ConvertRegistersToInt(templist.Skip(28).Take(2).ToArray(),
                        ModbusClient.RegisterOrder.HighLow));
                }
            }
            catch (Exception ex) {

                LogHelper.LogError(ex.Message);
            }
            

        }

        private void ReadAnalyArea4() {
            lock (_async) {
                List<int> templist = client.ReadHoldingRegisters(0, 20).ToList();
                XAxis.DestPostion = ModbusClient.ConvertRegistersToDouble(templist.Skip<int>(0).Take<int>(4).ToArray<int>(),
                       ModbusClient.RegisterOrder.HighLow);
                YAxis.DestPostion = ModbusClient.ConvertRegistersToDouble(templist.Skip<int>(4).Take<int>(4).ToArray<int>(),
                       ModbusClient.RegisterOrder.HighLow);
                ZAxis.DestPostion = ModbusClient.ConvertRegistersToDouble(templist.Skip<int>(8).Take<int>(4).ToArray<int>(),
                       ModbusClient.RegisterOrder.HighLow);
                Distence = ModbusClient.ConvertRegistersToDouble(templist.Skip<int>(12).Take<int>(4).ToArray<int>(),
                       ModbusClient.RegisterOrder.HighLow);
                JogSpeed = ModbusClient.ConvertRegistersToDouble(templist.Skip<int>(16).Take<int>(4).ToArray<int>(),
                       ModbusClient.RegisterOrder.HighLow);
            }
            
        }

        

        private void WriteData() {
            //写入bool数据
            WriteBool writeBool;
            while (WriteBoolData!=null&&WriteBoolData.Count>0) {
                if (WriteBoolData.TryDequeue(out writeBool)) {
                    if (writeBool != null) {
                        client.WriteSingleCoil(writeBool.StartAddress, writeBool.Value);
                    }
                }
            }
            //写入Double数据
            WriteDouble writeDouble;
            while (WriteDoubleData != null && WriteDoubleData.Count > 0) {
                if (WriteDoubleData.TryDequeue(out writeDouble)) {
                    if (writeDouble != null) {
                        client.WriteMultipleRegisters(writeDouble.StartAddress,ModbusClient.ConvertDoubleToRegisters(writeDouble.Value,ModbusClient.RegisterOrder.HighLow));
                    }
                }
            }
        }

        public void JogForwardStart(int axisID) {
            Task.Run(() => {
                lock (_async) {
                    switch (axisID) {
                        case 1:
                            client.WriteSingleCoil(0, true);
                            break;
                        case 2:
                            client.WriteSingleCoil(2, true);
                            break;
                        case 3:
                            client.WriteSingleCoil(4, true);
                            break;

                        default:
                            break;
                    }
                }
                
            });
            
        }
        public void JogForwardEnd(int axisID) {
            Task.Run(() => {
                lock (_async) {
                    switch (axisID) {
                        case 1:
                            client.WriteSingleCoil(0, false);
                            break;
                        case 2:
                            client.WriteSingleCoil(2, false);
                            break;
                        case 3:
                            client.WriteSingleCoil(4, false);
                            break;

                        default:
                            break;
                    }
                }
                
            });
            
        }
        public void JogBackwardStart(int axisID) {
            Task.Run(() => {
                lock (_async) {
                    switch (axisID) {
                        case 1:
                            client.WriteSingleCoil(1, true);
                            break;
                        case 2:
                            client.WriteSingleCoil(3, true);
                            break;
                        case 3:
                            client.WriteSingleCoil(5, true);
                            break;

                        default:
                            break;
                    }
                }
                
            });
            

        }
        public void JogBackwardEnd(int axisID) {
            Task.Run(() => {
                lock (_async) {
                    switch (axisID) {
                        case 1:
                            client.WriteSingleCoil(1, false);
                            break;
                        case 2:
                            client.WriteSingleCoil(3, false);
                            break;
                        case 3:
                            client.WriteSingleCoil(5, false);
                            break;

                        default:
                            break;
                    }
                }
                
            });
            
        }
        /// <summary>
        /// 回原点
        /// </summary>
        public void Homeing(int axisID) {
            Task.Run(() => {
                lock (_async) {
                    switch (axisID) {
                        case 1:
                            client.WriteSingleCoil(6, true);
                            client.WriteSingleCoil(6, false);
                            break;
                        case 2:
                            client.WriteSingleCoil(7, true);
                            client.WriteSingleCoil(7, false);
                            break;
                        case 3:
                            client.WriteSingleCoil(8, true);
                            client.WriteSingleCoil(8, false);
                            break;

                        default:
                            break;
                    }
                }
                
            });
            
        }
        /// <summary>绝对定位</summary>
        /// <param name="point">点位数据</param>
        /// <returns>定位成功</returns>
       public void PosAbsloute(AxisPoint point) {
            Task.Run(() => {
                lock (_async) {
                    List<int> ints = new List<int>();
                    ints.AddRange(ModbusClient.ConvertDoubleToRegisters(point.XAxisPostion, ModbusClient.RegisterOrder.HighLow));
                    ints.AddRange(ModbusClient.ConvertDoubleToRegisters(point.YAxisPostion, ModbusClient.RegisterOrder.HighLow));
                    ints.AddRange(ModbusClient.ConvertDoubleToRegisters(point.ZAxisPostion, ModbusClient.RegisterOrder.HighLow));
                    client.WriteMultipleRegisters(0, ints.ToArray());
                    client.WriteSingleCoil(11, true);
                    client.WriteSingleCoil(11, false);
                }
                
            });
            
        }
        /// <summary>
        /// 复位轴
        /// </summary>
        public void ResetAxis() {
            Task.Run(() => {
                lock (_async) {
                    client.WriteSingleCoil(9, true);
                    client.WriteSingleCoil(9, false);
                }
                
            });
        }
        /// <summary>
        /// 停止轴
        /// </summary>
        public void StopAxis() {
            Task.Run(() => {
                lock (_async) {
                    client.WriteSingleCoil(10, true);
                    client.WriteSingleCoil(10, false);
                }
               
            });
        }
        public void ModifyParam(double Dist,double JogSpeed) {
            Task.Run(() => {
                lock (_async) {
                    List<int> ints = new List<int>();
                    ints.AddRange(ModbusClient.ConvertDoubleToRegisters(Dist, ModbusClient.RegisterOrder.HighLow));
                    ints.AddRange(ModbusClient.ConvertDoubleToRegisters(JogSpeed, ModbusClient.RegisterOrder.HighLow));
                    client.WriteMultipleRegisters(12, ints.ToArray());
                }
                
            });
            
        }
    }

    public class WriteBool{
        public int StartAddress { get; set; }
        public bool Value { get; set; }
    }

    public class WriteDouble {
        public int StartAddress { get; set; }
        public double Value { get; set; }
    }
}
