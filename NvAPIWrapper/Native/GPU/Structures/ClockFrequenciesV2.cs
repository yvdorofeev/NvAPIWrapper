using System.Linq;
using System.Runtime.InteropServices;
using NvAPIWrapper.Native.Attributes;
using NvAPIWrapper.Native.General.Structures;
using NvAPIWrapper.Native.Interfaces;
using NvAPIWrapper.Native.Interfaces.GPU;

namespace NvAPIWrapper.Native.GPU.Structures
{
    /// <summary>
    ///     Holds a list of clock frequencies
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    [StructureVersion(2)]
    public struct ClockFrequenciesV2: IInitializable, IClockFrequencies
    {
        internal StructureVersion _Version;

        internal readonly uint _ClockType;
        
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        internal readonly ClockFrequenciesV3.GpuPublicClock[] _GpuClocks;

        public IGpuClock[] GpuClocks => _GpuClocks.Cast<IGpuClock>().ToArray();

        public IGpuClock GraphicsClock => GpuClocks.Length > ClockFrequenciesV3.GraphicsClockIndex
            ? GpuClocks[ClockFrequenciesV3.GraphicsClockIndex]
            : new ClockFrequenciesV3.GpuPublicClock();
        public IGpuClock MemoryClock => GpuClocks.Length > ClockFrequenciesV3.MemoryClockIndex
            ? GpuClocks[ClockFrequenciesV3.MemoryClockIndex]
            : new ClockFrequenciesV3.GpuPublicClock();
        public IGpuClock ProcessorClock => GpuClocks.Length > ClockFrequenciesV3.ProcessorClockIndex
            ? GpuClocks[ClockFrequenciesV3.ProcessorClockIndex]
            : new ClockFrequenciesV3.GpuPublicClock();
        public IGpuClock VideoClock => GpuClocks.Length > ClockFrequenciesV3.VideoClockIndex
            ? GpuClocks[ClockFrequenciesV3.VideoClockIndex]
            : new ClockFrequenciesV3.GpuPublicClock();
    }
}