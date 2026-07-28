using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using VideojuegoCliente.Comunicacion;
using VideojuegoServidor.Entidades;

/*
    UNED - Tercer cuatrimestre
    Curso: Programación Avanzada
    Proyecto 2
    Estudiante: Anthony Jafet Mendoza Rivas
    Descripción: Formulario para consultar las rondas de todas las batallas registradas.
    Muestra información detallada de cada ronda, incluyendo jugadores, criaturas atacantes
    y defensoras, así como el ganador de la ronda.
*/

namespace VideojuegoCliente.GUI.ConsultasForms
{
    public partial class FormConsRondas : Form
    {
        private readonly ClienteSocket socket;

        public FormConsRondas(ClienteSocket socket, int idJugador)
        {
            InitializeComponent();
            this.socket = socket;

            ConfigurarDataGridView();
            CargarRondas();
        }

        private void ConfigurarDataGridView()
        {
            dataGVRondas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGVRondas.Columns.Clear();

            dataGVRondas.Columns.Add("ColIdRonda", "ID Ronda");
            dataGVRondas.Columns.Add("ColIdBatalla", "ID Batalla");
            dataGVRondas.Columns.Add("ColNumeroRonda", "Número Ronda");

            dataGVRondas.Columns.Add("ColIdJugadorAtacante", "ID Jugador Atacante");
            dataGVRondas.Columns.Add("ColNombreJugadorAtacante", "Nombre Jugador Atacante");

            dataGVRondas.Columns.Add("ColIdJugadorDefensor", "ID Jugador Defensor");
            dataGVRondas.Columns.Add("ColNombreJugadorDefensor", "Nombre Jugador Defensor");

            dataGVRondas.Columns.Add("ColIdCriaturaAtacante", "ID Criatura Atacante");
            dataGVRondas.Columns.Add("ColNombreCriaturaAtacante", "Nombre Criatura Atacante");

            dataGVRondas.Columns.Add("ColIdCriaturaDefensor", "ID Criatura Defensor");
            dataGVRondas.Columns.Add("ColNombreCriaturaDefensor", "Nombre Criatura Defensor");

            dataGVRondas.Columns.Add("ColGanadorRonda", "Ganador de la ronda");
        }

        private void CargarRondas()
        {
            try
            {
                dataGVRondas.Rows.Clear();

                List<RondasEntidad> rondas = socket.ObtenerRondas();
                List<InventarioEntidad> inventarios = socket.ObtenerTodoInventario();
                List<JugadorEntidad> jugadores = socket.ObtenerJugadores();
                List<CriaturasEntidad> criaturas = socket.ObtenerCriaturas();

                if (rondas == null || rondas.Count == 0)
                    return;

                foreach (var ronda in rondas)
                {
                    // Buscar inventarios atacante y defensor
                    var inventarioAtacante = inventarios.Find(i => i.IdInventario == ronda.IdInventarioAtacante);
                    var inventarioDefensor = inventarios.Find(i => i.IdInventario == ronda.IdInventarioDefensor);

                    // De inventarios sacar jugadores y criaturas
                    JugadorEntidad jugadorAtacante = null;
                    JugadorEntidad jugadorDefensor = null;
                    CriaturasEntidad criaturaAtacante = null;
                    CriaturasEntidad criaturaDefensor = null;

                    if (inventarioAtacante != null)
                    {
                        jugadorAtacante = jugadores.Find(j => j.IdJugador == inventarioAtacante.IdJugador);
                        criaturaAtacante = criaturas.Find(c => c.IdCriatura == inventarioAtacante.IdCriatura);
                    }

                    if (inventarioDefensor != null)
                    {
                        jugadorDefensor = jugadores.Find(j => j.IdJugador == inventarioDefensor.IdJugador);
                        criaturaDefensor = criaturas.Find(c => c.IdCriatura == inventarioDefensor.IdCriatura);
                    }

                    // Nombre del ganador (suponiendo que GanadorRonda es IdJugador)
                    var ganador = jugadores.Find(j => j.IdJugador == ronda.GanadorRonda);

                    dataGVRondas.Rows.Add(
                        ronda.IdRonda,                   
                        ronda.IdBatalla,              
                        ronda.NumeroRonda,                 
                        inventarioAtacante?.IdJugador ?? 0,
                        jugadorAtacante != null ? jugadorAtacante.Nombre : $"Jugador {inventarioAtacante?.IdJugador ?? 0}", 
                        inventarioDefensor?.IdJugador ?? 0, 
                        jugadorDefensor != null ? jugadorDefensor.Nombre : $"Jugador {inventarioDefensor?.IdJugador ?? 0}", 
                        inventarioAtacante?.IdCriatura ?? 0, 
                        criaturaAtacante != null ? criaturaAtacante.Nombre : $"Criatura {inventarioAtacante?.IdCriatura ?? 0}", 
                        inventarioDefensor?.IdCriatura ?? 0, 
                        criaturaDefensor != null ? criaturaDefensor.Nombre : $"Criatura {inventarioDefensor?.IdCriatura ?? 0}", 
                        ganador != null ? ganador.Nombre : $"Jugador {ronda.GanadorRonda}" 
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar rondas: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
