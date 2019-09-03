using Ar.UTN.QMP.Lib.Entidades.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ar.UTN.QMP.Lib.Entidades.Core
{
    public class Notificador
    {
        private Notificador Instance { get; set; }

        public Notificador GetInstance()
        {
            if (Instance == null)
                return Instance = new Notificador();
            else
                return Instance;
        }

        public void Notificar(Usuario User)
        {
            // Enviar email
            //this.EnviarEmail(User.Email);

            // Enviar sms
            //this.EnviarSms(User.Telefono);

            // Enviar whatsapp
            //this.EnviarWhatApp(User.Telefono);
        }
        private void EnviarWhatApp(int telefono)
        {
            throw new NotImplementedException();
        }
        private void EnviarSms(int telefono)
        {
            throw new NotImplementedException();
        }
        private void EnviarEmail(string email)
        {
            throw new NotImplementedException();
        }
    }
}
