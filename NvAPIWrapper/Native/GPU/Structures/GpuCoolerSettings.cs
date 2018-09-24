using System;
using System.Linq;
using System.Runtime.InteropServices;
using NvAPIWrapper.Native.Attributes;
using NvAPIWrapper.Native.General.Structures;
using NvAPIWrapper.Native.Interfaces;
using NvAPIWrapper.Native.Interfaces.GPU;

namespace NvAPIWrapper.Native.GPU.Structures
{
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    [StructureVersion(1)]
    public struct GpuCoolerSettings: IInitializable
    {
        internal StructureVersion _Version;
        internal readonly uint _Count;
        
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)] 
        internal readonly GpuCoolerSetting[] _CoolerSettings;

        public IGpuCoolerSetting[] CoolerSettings =>
            _CoolerSettings.Take((int) _Count).Cast<IGpuCoolerSetting>().ToArray();

        [StructLayout(LayoutKind.Sequential)]
        public struct GpuCoolerSetting: IGpuCoolerSetting
        {
            internal readonly int _Type;
            internal readonly int _Controller;
            internal readonly uint _DefaultMinLevel;
            internal readonly uint _DefaultMaxLevel;
            internal readonly uint _CurrentMinLevel;
            internal readonly uint _CurrentMaxLevel;
            internal readonly uint _CurrentLevel;
            internal readonly int _DefaultPolicy;
            internal readonly int _CurrentPolicy;
            internal readonly int _Target;
            internal readonly int _ControlType;
            internal readonly int _Active;

            public CoolerType CoolerType => (CoolerType)_Type;
            public CoolerControllerType ControllerType => (CoolerControllerType) _Controller;
            public int DefaultMinLevel => (int)_DefaultMinLevel;
            public int DefaultMaxLevel => (int) _DefaultMaxLevel;
            public int CurrentMinLevel => (int) _CurrentMinLevel;
            public int CurrentMaxLevel => (int) _CurrentMaxLevel;
            public int CurrentLevel => (int) _CurrentLevel;
            public int DefaultPolicy => _DefaultPolicy;
            public int CurrentPolicy => _CurrentPolicy;
            public CoolerTarget CoolerTarget => (CoolerTarget) _Target;
            public int ControlType => _ControlType;
            public int Active => _Active;

            public override string ToString()
            {
                return $"Type: {CoolerType}, Current level: {CurrentLevel}, Target: {CoolerTarget}";
            }
        }
    }
}