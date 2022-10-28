using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TGOrganicos.Web.Models.Helpers
{
    public class ComboBox
    {
        public static SelectList GerarBox(IQueryable<SelectItem> lista, bool selecione = true, bool ordenar = true, string selecionado = null, string textoSelecione = "")
        {
            if (ordenar)
                lista = lista.OrderBy(c => c.Id);

            if (selecionado != null && selecionado != "")
                return new SelectList
                  (
                       lista,
                      "Id",
                      "Texto",
                      selecionado
                  );
            return new SelectList
              (
                   lista,
                  "Id",
                  "Texto"
              );
        }

        public static SelectList GerarBox(List<SelectItem> lista, bool selecione = true, bool ordenar = true, string selecionado = null, string textoSelecione = "")
        {
            if (ordenar)
                lista = lista.OrderBy(c => c.Id).ToList();

            if (selecione)
            {
                if (textoSelecione == "")
                    textoSelecione = "Selecione";
                lista.Insert(0, new SelectItem() { Id = 0, Texto = textoSelecione });
            }

            if (selecionado != null && selecionado != "")
                return new SelectList
                  (
                       lista,
                      "Id",
                      "Texto",
                      selecionado
                  );
            return new SelectList
              (
                   lista,
                  "Id",
                  "Texto"
              );
        }

        public static SelectList GerarBox(List<SelectItemLong> lista, bool selecione = true, bool ordenar = true, string selecionado = null, string textoSelecione = "")
        {
            if (ordenar)
                lista = lista.OrderBy(c => c.Texto).ToList();

            if (selecione)
            {
                if (textoSelecione == "")
                    textoSelecione = "Selecione";
                lista.Insert(0, new SelectItemLong() { Id = 0, Texto = textoSelecione });
            }

            if (selecionado != null && selecionado != "")
                return new SelectList
                  (
                       lista,
                      "Id",
                      "Texto",
                      selecionado
                  );
            return new SelectList
              (
                   lista,
                  "Id",
                  "Texto"
              );
        }
    }
}