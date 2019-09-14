using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TasklistProject1.Models
{
    public enum Status
    {
        ABERTO, CONCLUIDO
    }

    public class Tasklist
    {
        public int ID { get; set; }
        public string TaskTitulo { get; set; }
        public string TaskDescricao { get; set; }
        public DateTime TaskDataCriacao { get; set; }

        /**
         * O status é um enum
         */
        public Status TaskStatus { get; set; }
    }
}
