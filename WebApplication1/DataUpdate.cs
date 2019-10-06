using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Database1DataSetTableAdapters;
using static WebApplication1.Database1DataSet;

namespace WebApplication1
{
    public class DataUpdate
    {
        //Usar este metodo para actualizar los datos del estudiante despues de agregar una calificacion o modificar una calificacion
        public static void UpdateDatosEstudiante(string idEstudiante)
        {
            double indice = 0;
            int creditosAcumulados = 0;
            string honor = "";
            int cantidadCalificacion = 0;

            ListCalEstTableAdapter listCalEst = new ListCalEstTableAdapter();
            var calificaciones = listCalEst.GetDataByID(idEstudiante).Rows;
            cantidadCalificacion = calificaciones.Count;

            foreach (ListCalEstRow calificacion in calificaciones)
            {
                int multiplicador = 0;
                creditosAcumulados += (int)calificacion["Creditos"];
                string alpha = calificacion["Alpha"].ToString();
                if (alpha == "A") multiplicador = 4;
                else if (alpha == "B") multiplicador = 3;
                else if (alpha == "C") multiplicador = 2;
                else if (alpha == "D") multiplicador = 1;
                else if (alpha == "F") multiplicador = 0;
                indice += (int)calificacion["Creditos"]*multiplicador;
            }
            indice /= creditosAcumulados;
            indice = Math.Round(indice, 2);
            if (indice >= 3.80 && indice <= 4.00) honor = "Summa Cum Laude";
            else if (indice >= 3.60 && indice <= 3.79) honor = "Magna Cum Laude";
            else if (indice >= 3.40 && indice <= 3.59) honor = "Cum Laude";
            else honor = "Sin Honor";
            EstudiantesTableAdapter estudiantes = new EstudiantesTableAdapter();
            estudiantes.UpdateQueryDatosEst(indice.ToString("0.00"),creditosAcumulados,honor,cantidadCalificacion,idEstudiante);
        }
        public string GetID()
        {
            IdUsuariosTableAdapter idUsuariosTableAdapter = new IdUsuariosTableAdapter();
            idUsuariosTableAdapter.Insert();
            //return idUsuariosTableAdapter.GetData()[0].ToString();
            return idUsuariosTableAdapter.scope().ToString();
        }

        public static void UpdateEnUsoEntities(string idEst, string idProf, string clave)
        {
            var estudiantes = new EstudiantesTableAdapter();
            var profesores = new ProfesoresTableAdapter();
            var asignaturas = new AsignaturasTableAdapter();

            if(estudiantes.GetStudentsNotInUses(idEst).ToString() == "no")
            {
                estudiantes.UpdateEnUsoEst("si", idEst);
            }
            if(profesores.GetUse(idProf).ToString() == "no")
            {
                profesores.UpdateEnUsoProf("si", idProf);
            }
            if (asignaturas.GetUse(clave).ToString() == "no")
            {
                asignaturas.UpdateEnUsoAsig("si",clave);
            }
        }


    }
}