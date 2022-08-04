using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Comun;

namespace Entidades
{
    public delegate void DelegadoRonda(IJugador j1, IJugador j2);
    public delegate void DelegadoFinalizar(IJugador j);
    public sealed class Combate
    {
        Thread hilo;

        public event DelegadoRonda RondaIniciada;
        public event DelegadoFinalizar CombateFinalizado;

        private IJugador atacado;
        private IJugador atacante;
        private static Random random;

        static Combate()
        {
            random = new Random();
        }
        public Combate(IJugador j1, IJugador j2)
        {
            this.atacante = SeleccionarJugadorAleatoriamente(j1, j2);
            if(this.atacante == j1)
            {
                this.atacado = j2;
            } else { this.atacado = j1; }
            hilo = new Thread(Combatir);
        }
        private void Combatir() {
            IJugador ganador=null;
            IJugador perdedor = null;
            while (ganador!=null){
                IniciarRonda();
                ganador= EvaluarGanador();
            }
            if (ganador != null)
            {
                if(ganador == this.atacante) { perdedor = this.atacado; }
                else { perdedor = this.atacante; }

                DateTime d = DateTime.Now;
                CombateFinalizado?.Invoke(ganador);
                ResultadoCombate r = new ResultadoCombate(ganador.ToString(), perdedor.ToString(),d);
                ManejadorArchivos m = new ManejadorArchivos();
                m.GuardarXml(r);
            }
        }

        private IJugador EvaluarGanador() {
            IJugador aux;
            if (this.atacado.PuntosDeVida == 0) { return this.atacante; }
            else {
                aux = this.atacante;//puede fallar!
                this.atacante = this.atacado;
                this.atacado = aux;
                return null;
            }
        }
        public Thread IniciarCombate()
        {
            hilo.Start();
            return hilo;
        }
        private void IniciarRonda() {
            
            RondaIniciada?.Invoke(this.atacante, this.atacado);
            int pow = this.atacante.Atacar();
            this.atacado.RecibirAtaque(pow);
        }

        public static IJugador SeleccionarJugadorAleatoriamente(IJugador j1, IJugador j2)
        {
            if ((LadosMoneda)random.TirarMoneda() == LadosMoneda.Cara)
            {
                //Console.WriteLine("salio CARA");
                return j1;
            }
            //Console.WriteLine("salio CECA");
            return j2;
        }
        public static IJugador SeleccionarPrimerAtacante(IJugador j1, IJugador j2)
        {
            if (j1.Nivel > j2.Nivel) { return j2; }
            else if(j1.Nivel == j2.Nivel) 
            { return SeleccionarJugadorAleatoriamente(j1, j2); }
            else { return j1; }
        }
    }
}
