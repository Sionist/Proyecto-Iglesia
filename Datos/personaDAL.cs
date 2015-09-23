using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data.Entity;


namespace Datos
{
     public class personaDAL
    {
         //metodo de insercion en la BD tomando parametro tipo entidad persona
         public void insertar(persona persona) {

             using (IglesiaBD dbCon = new IglesiaBD()) 
             {
                 dbCon.persona.Add(persona);
                 dbCon.SaveChanges();
             }

         }
         //trae de la BD todos los registro de la tabla persona
         public List<personaDTO> traerTodo() { 

             using (IglesiaBD dbCon = new IglesiaBD()) 
             {
                 List<personaDTO> query = (from p in dbCon.persona.AsEnumerable()
                                        orderby p.nombres
                                        select new personaDTO(){
                                        cedula = p.cedula, 
                                        nombres = p.nombres, 
                                        apellidos = p.apellidos}
                                        ).ToList();
                 return query;
             }                    
         }

         //recupera registro a traves de su id tipo int
         public List<persona> traerPorID(int id) {

             using (IglesiaBD dbCon = new IglesiaBD())
             {
                 var query = from p in dbCon.persona
                             where p.IdPersona == id
                             select p;

                 if (query.ToList().Count() > 0) { 
                    return query.ToList();
                 }               
             }
             return null;         
         }

         //actulizar un registro existente
         public void actualizar(persona persona) {

             using (IglesiaBD dbCon = new IglesiaBD())
             {
                 dbCon.Entry(persona).State = EntityState.Modified;
                 dbCon.SaveChanges();
             }
         }

         public void eliminar(persona persona) {

             using (IglesiaBD dbCon = new IglesiaBD())
             {
                 dbCon.Entry(persona).State = EntityState.Deleted;
                 dbCon.SaveChanges();
             }
         }
    }
}
