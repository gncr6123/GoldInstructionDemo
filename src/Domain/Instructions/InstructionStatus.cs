namespace Domain.Instructions
{
    /// <summary>
    /// Talimatın durumlarını temsil eder.
    /// </summary>
    public enum InstructionStatus
    {
        Active,     // Talimat işlenmeye hazır durumda
        Completed,  // Talimat başarıyla tamamlandı
        Canceled    // Talimat iptal edildi
    }
}
