using System.Runtime.InteropServices;
using NvAPIWrapper.Native.GPU;

namespace NvAPIWrapper.Native.Interfaces.GPU
{
    public interface IGpuCoolerSetting
    {
        CoolerType CoolerType { get; }
        CoolerControllerType ControllerType { get; }
        int DefaultMinLevel { get; }
        int DefaultMaxLevel { get; }
        int CurrentMinLevel { get; }
        int CurrentMaxLevel { get; }
        int CurrentLevel { get; }
        int DefaultPolicy { get; }
        int CurrentPolicy { get; }
        CoolerTarget CoolerTarget { get; }
        int ControlType { get; }
        int Active { get; }
    }
}