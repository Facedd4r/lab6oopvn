namespace lab6oopvn
{
    /// <summary>
    /// enum Тип процессора (как вдохновение взято из встроенного enum Architecture)
    /// </summary>
    public enum CpuType
    {
        X86 = 0,
        //
        // Сводка:
        //     An Intel-based 64-bit processor architecture.
        X64 = 1,
        //
        // Сводка:
        //     A 32-bit ARM processor architecture.
        Arm = 2,
        //
        // Сводка:
        //     A 64-bit ARM processor architecture.
        Arm64 = 3,
        //
        // Сводка:
        //     The WebAssembly platform.
        Wasm = 4,
        //
        // Сводка:
        //     The S390x platform architecture.
        S390x = 5,
        //
        // Сводка:
        //     A LoongArch64 processor architecture.
        LoongArch64 = 6,
        //
        // Сводка:
        //     A 32-bit ARMv6 processor architecture.
        Armv6 = 7,
        //
        // Сводка:
        //     A PowerPC 64-bit (little-endian) processor architecture.
        Ppc64le = 8
    }
    
}