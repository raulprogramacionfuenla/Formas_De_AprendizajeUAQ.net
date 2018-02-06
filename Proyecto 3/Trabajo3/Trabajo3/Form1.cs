﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Media;

namespace Trabajo3
{
    public partial class Form1 : Form
    {
        private SoundPlayer _soundPlayer;
        private SoundPlayer _soundPlayer1;
        private SoundPlayer _soundPlayer2;
        private SoundPlayer _soundPlayer3;
        private SoundPlayer _soundPlayer4;
        public Form1()
        {
            InitializeComponent();
            _soundPlayer = new SoundPlayer("lbl_emocional.wav");
            _soundPlayer1 = new SoundPlayer("lbl_social.wav");
            _soundPlayer2 = new SoundPlayer("lbl_comunicacion_vida_profesional.wav");
            _soundPlayer3 = new SoundPlayer("btn_ejecutar.wav");
            _soundPlayer4 = new SoundPlayer("btn_regresar.wav");
        }

        private void btnEjecutar_Click(object sender, EventArgs e)
        {
            
            string texto = txtTexto.Text;
            string[] palabras;
            palabras = texto.Split(' ');
            int palAuditivas = 0;
            int palKinestesicas = 0;
            int palVisuales = 0;
            txtTexto.Clear();
            lbPalabras.Items.Clear();
            try
             {
               //ObtenerConexion.Conexion();
                for (int i = 0; i < palabras.Length; i++)
                {
                    lbPalabras.Items.Add(palabras[i]);

                    MySqlCommand consulta = new MySqlCommand("SELECT Palabras FROM `auditivo` WHERE Palabras LIKE '%" + palabras[i] + "%';", ObtenerConexion.Conexion());
                    MySqlDataReader resultado = consulta.ExecuteReader();
                    if (resultado.HasRows)
                    {
                        palAuditivas++;
                        //MessageBox.Show("Encontro una palabra en 'Auditivo'");
                    }

                    MySqlCommand consulta2 = new MySqlCommand("SELECT Palabras FROM `kinestesico` WHERE Palabras LIKE '%" + palabras[i] + "%';", ObtenerConexion.Conexion());
                    MySqlDataReader resultado2 = consulta2.ExecuteReader();
                    if (resultado2.HasRows)
                    {
                        palKinestesicas++;
                        //MessageBox.Show("Encontro una palabra en 'Kinestesica'");
                    }

                    MySqlCommand consulta3 = new MySqlCommand("SELECT Palabras FROM `visual` WHERE Palabras LIKE '%" + palabras[i] + "%';", ObtenerConexion.Conexion());
                    MySqlDataReader resultado3 = consulta3.ExecuteReader();
                    if (resultado3.HasRows)
                    {
                        palVisuales++;
                        //MessageBox.Show("Encontro una palabra en 'Visual'");
                    }

                    ObtenerConexion.Conexion().Close();
                }
                MessageBox.Show("Se detecto: \n" + palAuditivas + " palabras globales\n"+
                    palKinestesicas + " palabras estructurales\n" + palVisuales+" palabras integrales",
                    "La oracion introducida tiene: " + palabras.Length + " palabras");

                if (palAuditivas>palVisuales && palAuditivas>palKinestesicas){
                    Auditivo resultadoAud = new Auditivo();
                    resultadoAud.ShowDialog();
                }
                if (palVisuales > palKinestesicas && palVisuales > palAuditivas) {
                    Visual resultadoVis = new Visual();
                    resultadoVis.ShowDialog();
                }
                if (palKinestesicas > palVisuales && palKinestesicas > palAuditivas) {
                    Kinestesico resultadoKin = new Kinestesico();
                    resultadoKin.ShowDialog();
                }
                

             }
          catch (MySqlException ex) { 
           MessageBox.Show(string.Concat(ex)); 
           }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                checkBox1.Text = "Stop";
                _soundPlayer.Play();
            }
            else
            {
                checkBox1.Text = "Play";
                _soundPlayer.Stop();
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                checkBox2.Text = "Stop";
                _soundPlayer1.Play();
            }
            else
            {
                checkBox2.Text = "Play";
                _soundPlayer1.Stop();
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                checkBox3.Text = "Stop";
                _soundPlayer2.Play();
            }
            else
            {
                checkBox3.Text = "Play";
                _soundPlayer2.Stop();
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
            {
                checkBox4.Text = "Stop";
                _soundPlayer3.Play();
            }
            else
            {
                checkBox4.Text = "Play";
                _soundPlayer3.Stop();
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked)
            {
                checkBox5.Text = "Stop";
                _soundPlayer4.Play();
            }
            else
            {
                checkBox5.Text = "Play";
                _soundPlayer4.Stop();
            }
        }

        private void txtTexto_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
