using System.ComponentModel;

namespace SistemaDeTarefas.Enums
{
    public enum StatusTarefa
    {
        [Description("A fazer")]
        Afazer = 1,
        [Description("concluido")]
        EmAndamento = 2,
        [Description("Cconcluido")]
        Concluido = 3
    }
}
