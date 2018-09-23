using System;
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
    [StructureVersion(3)]
    public struct ClockFrequenciesV3: IInitializable, IClockFrequencies
    {
        internal const int GraphicsClockIndex = 0;
        internal const int MemoryClockIndex = 4;
        internal const int ProcessorClockIndex = 7;
        internal const int VideoClockIndex = 8;
        
        internal StructureVersion _Version;

        internal readonly uint _ClockType;
        
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        internal readonly GpuPublicClock[] _GpuClocks;

        public IGpuClock[] GpuClocks => _GpuClocks.Cast<IGpuClock>().ToArray();

        public IGpuClock GraphicsClock => GpuClocks.Length > GraphicsClockIndex
            ? GpuClocks[GraphicsClockIndex]
            : new GpuPublicClock();
        public IGpuClock MemoryClock => GpuClocks.Length > MemoryClockIndex
            ? GpuClocks[MemoryClockIndex]
            : new GpuPublicClock();
        public IGpuClock ProcessorClock => GpuClocks.Length > ProcessorClockIndex
            ? GpuClocks[ProcessorClockIndex]
            : new GpuPublicClock();
        public IGpuClock VideoClock => GpuClocks.Length > VideoClockIndex
            ? GpuClocks[VideoClockIndex]
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