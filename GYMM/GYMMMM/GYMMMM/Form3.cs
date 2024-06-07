using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace GYMMMM
{
    public partial class Form3 : MaterialSkin.Controls.MaterialForm
    {
        private DataTable dataTable;
        private int currentDayIndex;
        private List<List<string>> ejerciciosPorDia;

        public Form3()
        {
            InitializeComponent();
            InitializeDataTable();
            currentDayIndex = 0; // Inicializar en lunes
            ejerciciosPorDia = new List<List<string>>()
            {
                new List<string>(), // Lunes
                new List<string>(), // Martes
                new List<string>(), // Miércoles
                new List<string>(), // Jueves
                new List<string>(), // Viernes
            };
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            LoadDataGridView();
        }

        private void LoadDataGridView()
        {
            // Configurar el DataGridView
            dataGridView1.DataSource = dataTable;
        }

        private void InitializeDataTable()
        {
            // Inicializar DataTable con cinco columnas para los días de la semana
            dataTable = new DataTable();
            dataTable.Columns.Add("Lunes");
            dataTable.Columns.Add("Martes");
            dataTable.Columns.Add("Miércoles");
            dataTable.Columns.Add("Jueves");
            dataTable.Columns.Add("Viernes");
        }

        private void btnMostrarEjercicios_Click(object sender, EventArgs e)
        {
            if (currentDayIndex >= 5)
            {
                MessageBox.Show("Todos los días de la semana ya tienen ejercicios guardados.", "Límite alcanzado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Crear una lista para guardar los ejercicios seleccionados
            List<string> ejerciciosSeleccionados = new List<string>();

            // Recorrer cada CheckedListBox y agregar los ejercicios seleccionados a la lista
            foreach (var item in checkedListBox2.CheckedItems)
            {
                ejerciciosSeleccionados.Add(item.ToString());
            }

            foreach (var item in checkedListBox3.CheckedItems)
            {
                ejerciciosSeleccionados.Add(item.ToString());
            }

            foreach (var item in checkedListBox4.CheckedItems)
            {
                ejerciciosSeleccionados.Add(item.ToString());
            }

            // Obtener el nombre del día de la semana actual
            string[] diasDeLaSemana = { "Lunes", "Martes", "Miércoles", "Jueves", "Viernes" };
            string diaActual = diasDeLaSemana[currentDayIndex];

            // Agregar los ejercicios seleccionados a la lista correspondiente al día actual
            ejerciciosPorDia[currentDayIndex].AddRange(ejerciciosSeleccionados);

            // Actualizar la DataTable
            ActualizarDataTable();

            // Crear el mensaje con todos los ejercicios seleccionados
            string mensaje = $"Ejercicios guardados para {diaActual}:\n" + string.Join(Environment.NewLine, ejerciciosSeleccionados);

            // Mostrar el mensaje en un MessageBox
            MessageBox.Show(mensaje, "Ejercicios Guardados", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Incrementar el índice del día actual
            currentDayIndex++;
        }

        private void ActualizarDataTable()
        {
            dataTable.Rows.Clear();

            // Determinar el número máximo de ejercicios en cualquier día
            int maxRows = 0;
            foreach (var lista in ejerciciosPorDia)
            {
                if (lista.Count > maxRows)
                {
                    maxRows = lista.Count;
                }
            }

            // Agregar filas a la DataTable según el número máximo de ejercicios
            for (int i = 0; i < maxRows; i++)
            {
                DataRow row = dataTable.NewRow();

                for (int j = 0; j < 5; j++)
                {
                    if (i < ejerciciosPorDia[j].Count)
                    {
                        row[j] = ejerciciosPorDia[j][i];
                    }
                    else
                    {
                        row[j] = string.Empty;
                    }
                }

                dataTable.Rows.Add(row);
            }
        }

        // Los métodos restantes no necesitan cambios para esta funcionalidad específica

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Manejar el evento de clic en la celda si es necesario
        }

        private void checkedListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Manejar la selección de elementos en el CheckedListBox2
        }

        private void checkedListBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Manejar la selección de elementos en el CheckedListBox3
        }

        private void checkedListBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Manejar la selección de elementos en el CheckedListBox4
        }

        private void label9_Click(object sender, EventArgs e)
        {
            // Manejar el evento de clic en el Label9
        }

        private void label12_Click(object sender, EventArgs e)
        {
            // Manejar el evento de clic en el Label12
        }

        private void label13_Click(object sender, EventArgs e)
        {
            // Manejar el evento de clic en el Label13
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Manejar el evento de clic en el Button3
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            // Manejar el evento de clic en la celda si es necesario
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Manejar el cambio de texto en el TextBox1
        }

        private void checkedListBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            // Manejar la selección de elementos en el CheckedListBox2
        }
    }
}