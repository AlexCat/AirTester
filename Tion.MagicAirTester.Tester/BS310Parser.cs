using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Tion.MagicAirTester.Commands;
using Tion.MagicAirTester.Contracts;

namespace Tion.MagicAirTester.Tester
{
    /// <summary></summary>
    public class Bs310Parser<T>: IParser<T> where T: Command
    {
        public bool CheckResult(T currentCommand, List<string> data)
        {
            var concreteCommand = currentCommand as Bs310Command; 

            string stringifyData = string.Join(" ", data.ToArray());
            if (concreteCommand.CommandResult.Property == Bs310CommandResultProperty.PairingWithBreezer3S)
            {
                PairingWithBreezer3SParser(concreteCommand, stringifyData);
            }
            return false;
        }

        private void PairingWithBreezer3SParser(Bs310Command concreteCommand, string data)
        {
            throw new System.NotImplementedException();
        }

        /// <summary></summary>
        //    public static Note LastDeviceNote { get; set; } = new Note();

        //    /// <summary></summary>
        //    public static ParsedData Parse(string receivedData)
        //    {
        //        if (receivedData.Contains(Helper.WiFi.WiFiScanNet))
        //        {
        //            TionHelper.OnWiFi();
        //        }

        //        if (receivedData.Contains(Helper.Getver.Version))
        //        {
        //            string preparedData = ParseVersion(receivedData);

        //            LastDeviceNote.MagicAir.VersionInfo = preparedData;


        //            return new ParsedData
        //            {
        //                SensorTitle = "maInfo",
        //                Data = $"Версия: {preparedData}"
        //            };
        //        }
        //        if (receivedData.Contains(Helper.Getmac.Mac) && receivedData.Length < 25) // есть длинная строка с еще одним каким-то маком
        //        {
        //            string preparedData = ParseMac(receivedData);

        //            LastDeviceNote.MagicAir.MacAddress = preparedData;

        //            return new ParsedData
        //            {
        //                SensorTitle = "maInfo",
        //                Data = $"MAC-адрес: {preparedData}"
        //            };
        //        }

        //        // ПАРСИНГ ДЛЯ БРИЗЕРА
        //        // 1
        //        if (receivedData.Contains(Helper.Breather.Br) && receivedData.Contains(Helper.Breather.On) && receivedData.Contains(Helper.Breather.Man))
        //        {
        //            Debug.WriteLine("1 стр --------->" + receivedData);
        //            BreatherInfoSynchronizer(receivedData, BreatherInfoString.First);
        //        }

        //        // 2
        //        if (receivedData.Contains(Helper.Breather.To) && receivedData.Contains(Helper.Breather.Ti))
        //        {
        //            Debug.WriteLine("2 стр --------->" + receivedData);
        //            int index = receivedData.IndexOf("To");
        //            if (index > 0) // блок нужен для того, чтобы отсечь сегмент Flp=15 (из "Flp=15, To=24, Ti=39,"), который приходит из бризера 3.0.
        //            {
        //                receivedData = receivedData.Substring(index);
        //                receivedData = receivedData + ",";
        //            }
        //            BreatherInfoSynchronizer(receivedData, BreatherInfoString.Second);
        //        }

        //        // 4
        //        if (receivedData.Contains(Helper.Breather.Ts))
        //        {
        //            Debug.WriteLine("4 стр --------->" + receivedData);
        //            BreatherInfoSynchronizer(receivedData, BreatherInfoString.Fourth);
        //        }

        //        // 3 (изначально она была последней)
        //        if (receivedData.Contains(Helper.Breather.SpR))
        //        {
        //            Debug.WriteLine("3 стр --------->" + receivedData);
        //            BreatherDevice preparedData = BreatherInfoSynchronizer(receivedData, BreatherInfoString.Third);

        //            LastDeviceNote.BreatherDevice = preparedData;

        //            TionHelper.OnBreatherData(null, new MagicAirModelEventArgs(MagicAirModelEventType.BreatherData, NoteFieldType.Success));

        //            var PrintData = new
        //            {
        //                Number = preparedData.Number,
        //                State = preparedData.State == 1 ? "Вкл." : "Выкл.",
        //                ManualControl = preparedData.ManualControl == 1 ? "Вкл." : "Выкл.",
        //                ExternalChannelTemperature = preparedData.ExternalChannelTemperature,
        //                InternalChannelTemperature = preparedData.InternalChannelTemperature,
        //                FanSpeed = preparedData.FanSpeed,
        //                preparedData.TemperatureSet
        //            };

        //            return new ParsedData
        //            {
        //                SensorTitle = "breatherInfo",
        //                Data = $"  {PrintData.Number}\t{PrintData.State}\t{PrintData.ManualControl}\t{PrintData.ExternalChannelTemperature}\t{PrintData.InternalChannelTemperature}\t{PrintData.TemperatureSet}\t{PrintData.FanSpeed}"
        //            };
        //        }

        //        if (receivedData.Contains("V:"))
        //        {
        //            var a = 0;
        //        }

        //        if (receivedData.Contains(Helper.NewBreatherDevice.NewDeviceRFL1) && receivedData.Contains(Helper.NewBreatherDevice.NewDeviceHardwareVersion))
        //        {
        //            string hw = ParseAddNewBreaserHardwareVersion(receivedData);
        //            return new ParsedData
        //            {
        //                SensorTitle = "breatherHardwareVersion",
        //                Data = hw.Substring(4, hw.Length - 4)
        //            };
        //        }


        //        // КОНЕЦ ПАРСИНГА ДЛЯ БРИЗЕРА


        //        // НАЧАЛО ПАРСИНГА ДЛЯ ДАТЧИКОВ
        //        // приходит строка, разбитая надвое
        //        if (receivedData.Contains(Helper.Sensors.FLTR1) || (receivedData.Contains(Helper.Sensors.numCO2) && receivedData.Contains(Helper.Sensors.CO2)))
        //        {
        //            //Debug.WriteLine("Ловим все: ---------------------------------->" + receivedData);
        //            // это целая строка
        //            if (receivedData.Length > 80)
        //            {
        //                Debug.WriteLine("Целая: ---------------------------------->" + receivedData);
        //                SensorsInfo si = SensorsParserStringFull(receivedData);

        //                SensorsList.AddItem(si);

        //                return new ParsedData
        //                {
        //                    SensorTitle = "sensorsInfo",
        //                    Data = $"  {si.Temperature}\t{si.Humidity}\t{si.CO2}\t{si.TMCU}"
        //                };
        //            }

        //            // это первая часть строки
        //            if (receivedData.Contains(Helper.Sensors.FLTR1) && receivedData.Length < 80)
        //            {
        //                //Debug.WriteLine("Первая часть: ---------------------------------->" + receivedData);
        //                SensorSynchronizer(receivedData, SensorsStringPart.First);
        //            }

        //            // это вторая часть строки
        //            if ((receivedData.Contains(Helper.Sensors.numCO2) && receivedData.Contains(Helper.Sensors.CO2)))
        //            {
        //                //Debug.WriteLine("Вторая часть: ---------------------------------->" + receivedData);
        //                SensorsInfo si = SensorSynchronizer(receivedData, SensorsStringPart.Second);

        //                SensorsList.AddItem(si);

        //                return new ParsedData
        //                {
        //                    SensorTitle = "sensorsInfo",
        //                    Data = $"  {si.Temperature}\t{si.Humidity}\t{si.CO2}\t{si.TMCU}"
        //                };
        //            }

        //        }
        //        if (receivedData.Contains(Helper.NewBreatherDevice.NewDeviceMac))
        //        {
        //            string preparedData = ParseAddNewBreatherMac(receivedData);

        //            return new ParsedData
        //            {
        //                SensorTitle = "AddNewBreatherMac",
        //                Data = preparedData
        //            };
        //        }
        //        if (receivedData.Contains(Helper.NewBreatherDevice.NewDeviceType1) && receivedData.Contains(Helper.NewBreatherDevice.NewDeviceType2))
        //        {
        //            string preparedData = ParseAddNewBreatherType(receivedData);

        //            return new ParsedData
        //            {
        //                SensorTitle = "AddNewBreatherType",
        //                Data = preparedData
        //            };
        //        }

        //        return new ParsedData { SensorTitle = "delay" };
        //    }

        //    /// <summary>Очистить подготовленную для Excel запись</summary>
        //    public static void ClearNote()
        //    {
        //        LastDeviceNote.BreatherDevice.Number = -99;
        //        LastDeviceNote.BreatherDevice.State = -99;
        //        LastDeviceNote.BreatherDevice.ManualControl = -99;
        //        LastDeviceNote.BreatherDevice.ExternalChannelTemperature = -99.0;
        //        LastDeviceNote.BreatherDevice.InternalChannelTemperature = -99.0;
        //        LastDeviceNote.BreatherDevice.FanSpeed = -99;

        //        LastDeviceNote.MagicAir.VersionInfo = "-99";
        //        LastDeviceNote.MagicAir.WiFiName = "-99";
        //        LastDeviceNote.MagicAir.TMCUAverage = -99;
        //        LastDeviceNote.MagicAir.TemperatureAverage = -99;
        //        LastDeviceNote.MagicAir.HumidityAverage = -99;
        //        LastDeviceNote.MagicAir.CO2Average = -99;
        //        LastDeviceNote.MagicAir.MacAddress = "-99";
        //    }

        //    /// <summary>Парсер версии</summary>
        //    private static string ParseVersion(string rawVersionInfo)
        //    {
        //        return rawVersionInfo.Substring(12, rawVersionInfo.Length - 12);
        //    }

        //    /// <summary>Парсер MAC-адреса</summary>
        //    private static string ParseMac(string rawMacInfo)
        //    {
        //        return rawMacInfo.Substring(5, rawMacInfo.Length - 5);
        //    }

        //    private static SensorsInfo SensorsParserStringFull(string rawSensorsInfo)
        //    {
        //        string t = string.Empty, h = string.Empty, co2 = string.Empty, tmcu = string.Empty;
        //        double tval, hval, co2val, tmcuval;
        //        bool isT = false, isH = false, isCo2 = false, isTmcu = false;

        //        string[] splitByColon = rawSensorsInfo.Split(':');

        //        // парсинг температуры
        //        t = splitByColon[2].Split(',')[0];
        //        t = t.Substring(t.IndexOf('=') + 1, t.Length - t.IndexOf('=') - 1);

        //        // влажности
        //        h = splitByColon[2].Split(',')[1];
        //        h = h.Substring(h.IndexOf('=') + 1, h.Length - h.IndexOf('=') - 1);

        //        // co2
        //        co2 = splitByColon[3].Split(',')[0];
        //        co2 = co2.Substring(co2.IndexOf('=') + 1, co2.Length - co2.IndexOf('=') - 1);

        //        // температуры процессора
        //        tmcu = splitByColon[3].Split(',')[1];
        //        tmcu = tmcu.Substring(tmcu.IndexOf('=') + 1, tmcu.Length - tmcu.IndexOf('=') - 1);

        //        if (double.TryParse(t.Replace('.', ','), out tval))
        //        {
        //            isT = true;
        //        }
        //        if (double.TryParse(h.Replace('.', ','), out hval))
        //        {
        //            isH = true;
        //        }
        //        if (double.TryParse(co2.Replace('.', ','), out co2val))
        //        {
        //            isCo2 = true;
        //        }
        //        if (double.TryParse(tmcu.Replace('.', ','), out tmcuval))
        //        {
        //            isTmcu = true;
        //        }

        //        return new SensorsInfo
        //        {
        //            Timestamp = (int)DateTime.Now.Subtract(new DateTime(1970, 1, 1)).TotalSeconds,
        //            Temperature = isT ? tval : -98,
        //            Humidity = isH ? hval : -98,
        //            CO2 = isCo2 ? co2val : -98,
        //            TMCU = isTmcu ? tmcuval : -98
        //        };
        //    }


        //    private static string FullBreatherString = string.Empty;
        //    private static BreatherDevice BreatherInfoSynchronizer(string receivedData, BreatherInfoString str)
        //    {
        //        switch (str)
        //        {
        //            case BreatherInfoString.First:
        //                {
        //                    FullBreatherString = receivedData;
        //                    return null;
        //                }
        //            case BreatherInfoString.Second:
        //                {
        //                    FullBreatherString += receivedData;
        //                    return null;
        //                }
        //            case BreatherInfoString.Fourth:
        //                {
        //                    FullBreatherString += receivedData;
        //                    return null;
        //                }

        //            case BreatherInfoString.Third:
        //                {
        //                    FullBreatherString += receivedData;
        //                    Debug.WriteLine("Полная строка бризера собрана ==========> " + FullBreatherString);
        //                    string clone = FullBreatherString;
        //                    FullBreatherString = string.Empty;
        //                    return BreatherStringParser(clone);
        //                }
        //            default:
        //                {
        //                    return null;
        //                }
        //        }
        //    }

        //    private static BreatherDevice BreatherStringParser(string fullStringBreather)
        //    {
        //        string br, on, man, To, Ti, Ts, SpR;
        //        int brval, onval, manval, SpRval;
        //        double Toval, Tival, Tsval;

        //        string[] splitByColon = fullStringBreather.Split(':');
        //        string[] splitBySemicolon = splitByColon[1].Split(',');

        //        Debug.WriteLine("Из парсера ----->" + splitByColon[1]);

        //        br = splitByColon[0];
        //        br = br.Substring(br.IndexOf(' ') + 1, br.Length - br.IndexOf(' ') - 1); // br

        //        on = splitBySemicolon[0];
        //        on = on.Substring(on.IndexOf('=') + 1, on.Length - on.IndexOf('=') - 1); // on=0;

        //        man = splitBySemicolon[1];
        //        man = man.Substring(man.IndexOf('=') + 1, man.Length - man.IndexOf('=') - 1); // man=0

        //        To = splitBySemicolon[4];
        //        To = To.Substring(To.IndexOf('=') + 1, To.Length - To.IndexOf('=') - 1); // To=24

        //        Ti = splitBySemicolon[5];
        //        Ti = Ti.Substring(Ti.IndexOf('=') + 1, Ti.Length - Ti.IndexOf('=') - 1); // Ti=24

        //        Ts = splitBySemicolon[6].Contains("Ts=") ? splitBySemicolon[6] : "-99";
        //        Ts = Ts.Substring(Ts.IndexOf('=') + 1, Ts.Length - Ts.IndexOf('=') - 1);

        //        SpR = splitBySemicolon[6].Contains("Ts=") ? splitBySemicolon[7] : splitBySemicolon[6]; // SpR - Внезавпно приходящая строка может содержать в сегменте 6 др. данные
        //        SpR = SpR.Substring(SpR.IndexOf('=') + 1, SpR.Length - SpR.IndexOf('=') - 1); // SpR=3

        //        bool isBr = int.TryParse(br, out brval);
        //        bool isOn = int.TryParse(on, out onval);
        //        bool isMan = int.TryParse(man, out manval);
        //        bool isSpr = int.TryParse(SpR, out SpRval);
        //        bool isTo = double.TryParse(To, out Toval);
        //        bool isTi = double.TryParse(Ti, out Tival);
        //        bool isTs = double.TryParse(Ts, out Tsval);

        //        return new BreatherDevice
        //        {
        //            Number = isBr ? brval : -98,
        //            State = isOn ? onval : -98,
        //            ManualControl = isMan ? manval : -98,
        //            ExternalChannelTemperature = isTo ? Toval : -98,
        //            InternalChannelTemperature = isTi ? Tival : -98,
        //            FanSpeed = isSpr ? SpRval : -98,
        //            TemperatureSet = isTs ? Tsval : -98
        //        };
        //    }


        //    private static string FullSensorsString = string.Empty;
        //    private static SensorsInfo SensorSynchronizer(string receivedData, SensorsStringPart part)
        //    {
        //        if (FullSensorsString.Length == 0 && part == SensorsStringPart.First) // строка пуста и пришел первый сегмент
        //        {
        //            FullSensorsString = receivedData;
        //            return null;
        //        }

        //        if (part == SensorsStringPart.Second)
        //        {
        //            FullSensorsString += receivedData;
        //        }

        //        Debug.WriteLine("Строка по датчикам собрана ----------> " + FullSensorsString);

        //        //SensorsParserStringFull(FullSensorsString);
        //        var cloneString = FullSensorsString;
        //        FullSensorsString = string.Empty;
        //        return SensorsParserStringFull(cloneString);
        //    }

        //    private static string ParseAddNewBreatherMac(string receivedData)
        //    {
        //        string breatherMac, breatherType = Helper.Note.Unfilled;

        //        try
        //        {
        //            string[] splitByComma = receivedData.Split(',');

        //            int start = receivedData.IndexOf("MAC-") + 4;
        //            breatherMac = splitByComma[0].Substring(start, splitByComma[0].Length - start);
        //        }
        //        catch
        //        {
        //            breatherMac = Helper.Note.Undefined;
        //        }

        //        return breatherMac;
        //    }

        //    private static string ParseAddNewBreatherType(string receivedData)
        //    {
        //        string breatherType;
        //        try
        //        {
        //            string[] splitByComma = receivedData.Split(',');
        //            breatherType = splitByComma[1].Substring(6, splitByComma[1].Length - 6);
        //        }
        //        catch
        //        {
        //            breatherType = Helper.Note.Undefined;
        //        }

        //        string deviceName;
        //        switch (breatherType)
        //        {
        //            case "0x1004":
        //                {
        //                    deviceName = "(Breezer 1.9 MAC)";
        //                    break;
        //                }
        //            case "0x1007":
        //                {
        //                    deviceName = "(Breezer 3S)";
        //                    break;
        //                }
        //            default:
        //                {
        //                    deviceName = "Unknown";
        //                    break;
        //                }
        //        }

        //        return breatherType + " " + deviceName;
        //    }

        //    private static string ParseAddNewBreaserHardwareVersion(string receivedData)
        //    {
        //        string hw;
        //        try
        //        {
        //            string[] splitByComma = receivedData.Split(',');
        //            hw = splitByComma[5];
        //        }
        //        catch
        //        {
        //            hw = Helper.Note.Undefined;
        //        }

        //        return hw;
        //    }

        //    /// <summary>
        //    /// Добавляет дополнительный аргумент к событию, показывающий, какое именно значение было записано в модель
        //    /// </summary>
        //    public static NoteFieldType ValueChecker(string value)
        //    {
        //        if (value == "-99" || value == "-99.0")
        //        {
        //            return NoteFieldType.Error;
        //        }

        //        if (value == "-98" || value == "-98.0")
        //        {
        //            return NoteFieldType.ParseError;
        //        }

        //        return NoteFieldType.Success;
        //    }

        //    /// <summary>
        //    /// Перед сохранением документа заполняет определенные поля в авторежиме
        //    /// </summary>
        //    public static void FillDerivedField(string serialNumber)
        //    {
        //        LastDeviceNote.CheckingTime = DateTime.Now.ToString("MM:dd HH:mm:ss", CultureInfo.InvariantCulture);

        //        SensorsInfo sensorsAverageValue = SensorsList.GetAverageSensorsInfo();
        //        LastDeviceNote.MagicAir.TemperatureAverage = sensorsAverageValue.Temperature;
        //        LastDeviceNote.MagicAir.HumidityAverage = sensorsAverageValue.Humidity;
        //        LastDeviceNote.MagicAir.CO2Average = sensorsAverageValue.CO2;
        //        LastDeviceNote.MagicAir.TMCUAverage = sensorsAverageValue.TMCU;

        //        if (ValueChecker(LastDeviceNote.MagicAir.WiFiName = LastDeviceNote.MagicAir.MacAddress) == NoteFieldType.Success)
        //        {
        //            LastDeviceNote.MagicAir.WiFiName = "MagicAir_" + LastDeviceNote.MagicAir.MacAddress.Replace(":", "").Substring(0, 6);
        //        }
        //        else
        //        {
        //            LastDeviceNote.MagicAir.WiFiName = Helper.Note.ErrorNote;
        //        }

        //        LastDeviceNote.MagicAir.SerialNumber = serialNumber;
        //    }

        //    // методы расширения
        //    public static string StateToString(this string value)
        //    {
        //        if (value == "1")
        //        {
        //            return "Вкл.";
        //        }
        //        if (value == "0")
        //        {
        //            return "Выкл.";
        //        }
        //        return value;
        //    }

        //    public static string ReplaceIfError(this string value)
        //    {
        //        if (value == "-99" || value == "-99.0")
        //        {
        //            return "НЕ ОПРЕД";
        //        }
        //        if (value == "-98" || value == "-98.0")
        //        {
        //            return "ОШБ ПАРС";
        //        }
        //        return value;
        //    }


        //    static class Helper
        //    {
        //        public struct Getver
        //        {
        //            public const string Version = "VERSION: FV-";
        //        }

        //        public struct Getmac
        //        {
        //            public const string Mac = "MAC";
        //        }

        //        public struct Breather
        //        {
        //            // 1 строка
        //            public const string Br = "br";
        //            public const string On = "on";
        //            public const string Man = "man";
        //            // 2 строка
        //            public const string To = "To";
        //            public const string Ti = "Ti";
        //            // 3 строка
        //            public const string SpR = "SpR";
        //            // 4 строка
        //            public const string Ts = "Ts";
        //        }

        //        public struct NewBreatherDevice
        //        {
        //            public const string NewDeviceMac = "rf_device_reg_dev: add new device";
        //            public const string NewDeviceType1 = "Type=";
        //            public const string NewDeviceType2 = "SbType=";

        //            public const string NewDeviceRFL1 = "RFL: 1";
        //            public const string NewDeviceHardwareVersion = "FV:";

        //        }

        //        public struct Sensors
        //        {
        //            public const string FLTR1 = "[FLTR1]cz_task:";
        //            public const string numCO2 = "numCO2=";
        //            public const string CO2 = "CO2=";
        //        }

        //        public struct WiFi
        //        {
        //            public const string WiFiScanNet = "wifi_scan_net";
        //        }

        //        public struct Note
        //        {
        //            public const string ErrorNote = "НЕИЗВ";
        //            public const string On = "Вкл.";
        //            public const string Off = "Выкл.";
        //            public const string Unfilled = "НЕ ЗАПОЛНЕНО";
        //            public const string Undefined = "НЕ ОПРЕДЕЛЕНО";
        //        }
        //    }

        //    enum SensorsStringPart
        //    {
        //        First, Second
        //    }

        //    enum BreatherInfoString
        //    {
        //        First, Second, Third, Fourth
        //    }
        //}

    }
}
