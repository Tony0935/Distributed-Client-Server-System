using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VideojuegoServidor.GUI
{
    public static class BitacoraLog
    {
        public static DataGridView Bitacora;

        public static void Registrar(string accion, string resultado)
        {
            if (Bitacora == null) return;

            Bitacora.Invoke(new Action(() =>
            {
                Bitacora.Rows.Add(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), accion, resultado);
            }));
        }
    }
}
