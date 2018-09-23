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
    public struct ClockFrequenciesV1: IInitializable, IClockFrequencies
    {
        internal StructureVersion _Version;
        internal uint _Reserved;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        internal readonly GpuPublicClock[] _GpuClocks;

        public IGpuClock[] GpuClocks => _GpuClocks.Cast<IGpuClock>().ToArray();
        
        public IGpuClock GraphicsClock => GpuClocks.Length > ClockFrequenciesV3.GraphicsClockIndex
            ? GpuClocks[ClockFrequenciesV3.GraphicsClockIndex]
            : new GpuPublicClock();
        public IGpuClock MemoryClock => GpuClocks.Length > ClockFrequenciesV3.MemoryClockIndex
            ? GpuClocks[ClockFrequenciesV3.MemoryClockIndex]
            : new GpuPublicClock();
        public IGpuClock ProcessorClock => GpuClocks.Length > ClockFrequenciesV3.ProcessorClockIndex
            ? GpuClocks[ClockFrequenciesV3.ProcessorClockIndex]
            : new GpuPublicClock();
        public IGpuClock VideoClock => GpuClocks.Length > ClockFrequenciesV3.VideoClockIndex
            ? GpuClocks[ClockFrequenciesV3.VideoClockIndex]
            : new GpuPublicClock();

        [StructLayout(LayoutKind.Sequential)]
        public struct GpuPublicClock: IGpuClock
        {
            internal readonly uint _BlsPresent;
            internal readonly uint _Frequency;

            public int Frequency => (int)_Frequency;

            public override string ToString()
            {
                return $"Frequency: {Frequency}kHz";
            }
        }
    }
}