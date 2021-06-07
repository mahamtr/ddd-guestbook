namespace CleanArchitecture.Core.Helpers
{
    public enum PropuestasStatus
    {
        EnRevision,
        EnProceso,
        Aceptado,
        Rechazado,
    }
    
    public static class PropuestasStatusExtensions
    {
        public static string ToFriendlyString(this PropuestasStatus? status)
        {
            switch (status)
            {
                case PropuestasStatus.Rechazado: return "Rechazado";
                case PropuestasStatus.Aceptado: return "Aceptado";
                case PropuestasStatus.EnProceso: return "En proceso";
                case PropuestasStatus.EnRevision: return "En revisión";
            }
            return "";
        }
    }
}