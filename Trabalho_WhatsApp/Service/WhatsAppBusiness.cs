using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Interfaces;
using OpenQA.Selenium.Appium.MultiTouch;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trabalho_WhatsApp.Service
{
    class WhatsAppBusiness
    {
        #region Variaveis
        private AppiumDriver<AndroidElement> driver;
        #endregion

        #region Abrir-Fechar-Scroll
        public bool Abrir_App(string udid, string versao)
        {
            bool retorno = true;
            try
            {
                int timeOutInSeconds = 600;
                var appOptions = new AppiumOptions();
                appOptions.AddAdditionalCapability("platformName", "android");
                appOptions.AddAdditionalCapability("noReset", "true");
                appOptions.AddAdditionalCapability("platformVersion", versao);
                appOptions.AddAdditionalCapability("appPackage", "com.whatsapp.w4b");
                appOptions.AddAdditionalCapability("appActivity", "com.whatsapp.HomeActivity");
                appOptions.AddAdditionalCapability("udid", udid);
                appOptions.AddAdditionalCapability("newCommandTimeout", 0);
                driver = new AndroidDriver<AndroidElement>(new Uri("http://127.0.0.1:4723/wd/hub"), appOptions, TimeSpan.FromSeconds(timeOutInSeconds));
            }
            catch { retorno = false; }
            return retorno;
        }
        public void Fechar()
        {
            try
            {
                driver.CloseApp();
            }
            catch { }
        }
        public void Scroll(int xInit, int yInit, int xEnd, int yEnd)
        {
            Thread.Sleep(TimeSpan.FromSeconds(1));
            ITouchAction touchAction = new TouchAction(driver)
            .Press(xInit, yInit)
            .Wait(500)
            .MoveTo(xEnd, yEnd)
            .Release();

            touchAction.Perform();
        }
        #endregion

        #region Tela Conversa
        public void Entra_Primeira_Conversa()
        {
            try
            {
                Thread.Sleep(TimeSpan.FromMilliseconds(500));
                var all_Conversas = driver.FindElementsByXPath("//*[@class='android.widget.RelativeLayout']");
                foreach (AndroidElement conversa in all_Conversas)
                {
                    conversa.Click();
                    break;
                }

            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message + " Entra_Primeira_Conversa");
            }

        }
        public int Total_Conversas()
        {
            int retorno = 0;
            try
            {
                Thread.Sleep(TimeSpan.FromMilliseconds(500));
                var all_Conversas = driver.FindElementsByXPath("//android.widget.RelativeLayout[@resource-id='com.whatsapp.w4b:id/contact_row_container']");
                retorno = all_Conversas.Count;

            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message + " Total_Conversas");
            }
            return retorno;
        }
        public bool Entrar_Conversa_Pendente()
        {
            System.Collections.ObjectModel.ReadOnlyCollection<AndroidElement> conversas_pendentes;
            try
            {
                Thread.Sleep(TimeSpan.FromSeconds(1));
                conversas_pendentes = driver.FindElementsByXPath("//android.widget.TextView[@resource-id='com.whatsapp.w4b:id/conversations_row_message_count']");
                if (conversas_pendentes.Count > 0)
                {
                    conversas_pendentes[0].Click();
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch
            {
                return false;
            }
        }
        public void Selecionar_Conversas()
        {
            try
            {
                Thread.Sleep(TimeSpan.FromSeconds(1));
                var all_Conversas = driver.FindElementsByXPath("//android.widget.RelativeLayout[@resource-id='com.whatsapp.w4b:id/contact_row_container']");
                TouchAction touch = new TouchAction(driver);
                bool p = false;
                foreach (AndroidElement conversa in all_Conversas)
                {
                    if (p == false)
                    {
                        touch.LongPress(conversa).Perform();
                        Thread.Sleep(TimeSpan.FromSeconds(1));
                        p = true;
                    }
                    else
                    {
                        conversa.Click();
                    }
                }

            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message + " Selecionar_Conversas");
            }

        }
        #endregion

        #region Contatos
        public void Clicar_Contatos()
        {
            try
            {
                Thread.Sleep(TimeSpan.FromMilliseconds(500));
                var btn = driver.FindElement(By.XPath("//android.widget.ImageButton[@resource-id='com.whatsapp.w4b:id/fab']"));
                if (btn != null)
                {
                    btn.Click();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + " ClicarContatos");
            }
        }
        public void Clicar_Lupa_Procurar_Contatos()
        {
            try
            {
                Thread.Sleep(TimeSpan.FromMilliseconds(500));
                var btn = driver.FindElement(By.XPath("//android.widget.TextView[@resource-id='com.whatsapp.w4b:id/menuitem_search']"));
                if (btn != null)
                {
                    btn.Click();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + " ClicarLupaProcurarContatos");
            }
        }
        public void Digitar_Barra_Pesquisar_Contatos(string contato)
        {
            try
            {
                Thread.Sleep(TimeSpan.FromMilliseconds(500));

                var barra = driver.FindElement(By.XPath("//android.widget.EditText[@resource-id='com.whatsapp.w4b:id/search_src_text']"));
                if (barra != null)
                {
                    Actions action = new Actions(driver);

                    char[] Numeros = contato.ToCharArray();

                    foreach (char numero in Numeros)
                    {
                        action = new Actions(driver);
                        action.SendKeys(numero.ToString()).Perform();

                        Random rnd = new Random();
                        int x = rnd.Next(1500, 2000);
                        Thread.Sleep(TimeSpan.FromMilliseconds(x));
                    }

                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + " DigitarBarraPesquisarContatos");
            }
        }
        public bool Contato_Encontrado()
        {
            //nenhum resultado para o numero xxxxxx tem q melhorar 
            bool retorno = true;
            try
            {
                Thread.Sleep(TimeSpan.FromMilliseconds(500));
                var btn = driver.FindElement(By.XPath("//android.widget.Button[@resource-id='com.whatsapp.w4b:id/invite']"));
                if (btn != null)
                {
                    retorno = false;
                }
            }
            catch { }
            try
            {
                //Thread.Sleep(TimeSpan.FromMilliseconds(500));
                var txt = driver.FindElement(By.XPath("//android.widget.TextView[@resource-id='com.whatsapp.w4b:id/contactpicker_row_name']"));
                if (txt != null)
                {
                    if (txt.Text.Contains("Sem resultados para"))
                    {
                        retorno = false;
                    }

                }
            }
            catch { }

            return retorno;
        }
        public void Limpar_Barra_Pesquisar_Contatos()
        {
            try
            {
                Thread.Sleep(TimeSpan.FromMilliseconds(500));
                var btn = driver.FindElement(By.XPath("//android.widget.ImageView[@content-desc='Limpar consulta']"));
                if (btn != null)
                {
                    btn.Click();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + " LimparBarraPesquisarContatos");
            }
        }
        public void Clicar_Contato_Encontrato()
        {
            try
            {
                Thread.Sleep(TimeSpan.FromMilliseconds(500));
                var btn = driver.FindElement(By.XPath("//android.widget.TextView[@resource-id='com.whatsapp.w4b:id/contactpicker_row_name']"));
                if (btn != null)
                {
                    btn.Click();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + " ClicarEmContatoEncontrato");
            }
        }
        #endregion

        #region Envio Dentro da Conversa
        public void Clicar_Voltar()
        {
            try
            {
                Thread.Sleep(TimeSpan.FromMilliseconds(500));
                var btn = driver.FindElement(By.XPath("//android.widget.ImageView[@resource-id='com.whatsapp.w4b:id/whatsapp_toolbar_home']"));
                if (btn != null)
                {
                    btn.Click();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + " ClicarVoltar");
            }
        }
        public string Clicar_Perfil()
        {
            string retorno = string.Empty;
            try
            {
                Thread.Sleep(TimeSpan.FromMilliseconds(500));
                var btn = driver.FindElement(By.XPath("//android.widget.TextView[@resource-id='com.whatsapp.w4b:id/conversation_contact_name']"));
                if (btn != null)
                {
                    retorno = btn.Text;
                    btn.Click();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + " Clicar_Perfil");
            }
            return retorno;
        }
        public string DescobrirNumero()
        {
            string retorno = string.Empty;
            try
            {
                Thread.Sleep(TimeSpan.FromMilliseconds(500));
                var txt = driver.FindElement(By.XPath("//android.widget.TextView[@resource-id='com.whatsapp.w4b:id/title_tv']"));
                if (txt != null)
                {
                    retorno = txt.Text.Replace("+55", "").Replace("-", "").Replace(" ", "");

                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + " Clicar_Perfil");
            }
            return retorno;
        }
        public void Clicar_Inserir()
        {
            try
            {
                Thread.Sleep(TimeSpan.FromMilliseconds(500));
                var btn = driver.FindElement(By.XPath("//android.widget.ImageButton[@resource-id='com.whatsapp.w4b:id/input_attach_button']"));
                if (btn != null)
                {
                    btn.Click();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + " ClicarInserir");
            }
        }
        public void Clicar_Galeria()
        {
            try
            {
                Thread.Sleep(TimeSpan.FromMilliseconds(500));
                var btn = driver.FindElement(By.XPath("//android.widget.LinearLayout[@resource-id='com.whatsapp.w4b:id/pickfiletype_gallery_holder']"));
                if (btn != null)
                {
                    btn.Click();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + " ClicarGaleria");
            }
        }
        public void Clicar_Pasta_Pictures()
        {
            try
            {
                Thread.Sleep(TimeSpan.FromMilliseconds(500));
                var btn = driver.FindElement(By.XPath("//android.widget.TextView[@text='Pictures']"));
                if (btn != null)
                {
                    btn.Click();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + " ClicarPastaPictures");
            }
        }
        public void Selecionar_Imagens_Pictures()
        {
            try
            {
                Thread.Sleep(TimeSpan.FromMilliseconds(500));
                var all_Photos = driver.FindElementsByXPath("//*[@class='android.widget.ImageView']");
                TouchAction touch = new TouchAction(driver);
                bool p = false;
                foreach (AndroidElement img in all_Photos)
                {
                    if (p == false)
                    {
                        touch.LongPress(img).Perform();
                        Thread.Sleep(TimeSpan.FromMilliseconds(500));
                        p = true;
                    }
                    else
                    {
                        img.Click();
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + " SelecionarImagensPictures");
            }

        }
        public void Confirmar_Selecao_Imagens_Pictures()
        {
            try
            {
                Thread.Sleep(TimeSpan.FromMilliseconds(500));
                var btn = driver.FindElement(By.XPath("//android.widget.TextView[@text='OK']"));
                if (btn != null)
                {
                    btn.Click();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + " ConfirmarSelecaoImagens");
            }
        }
        public void Clicar_Enviar()
        {
            try
            {
                Thread.Sleep(TimeSpan.FromSeconds(1));
                var btn = driver.FindElement(By.XPath("//android.widget.ImageButton[@resource-id='com.whatsapp.w4b:id/send']"));
                if (btn != null)
                {
                    btn.Click();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + " ClicarEnviar");
            }
        }
        public void Digitar_Mensagem(string texto)
        {
            try
            {
                Thread.Sleep(TimeSpan.FromMilliseconds(500));
                var txtEdit = driver.FindElement(By.XPath("//android.widget.EditText[@resource-id='com.whatsapp.w4b:id/entry']"));
                txtEdit.SendKeys(texto);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + " DigitarMensagem");
            }
        }
        public void Clicar_Opcoes()
        {
            try
            {
                Thread.Sleep(TimeSpan.FromMilliseconds(500));
                var btn = driver.FindElement(By.XPath("//android.widget.ImageView[@content-desc='Mais opções']"));
                if (btn != null)
                {
                    btn.Click();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + " ClicarOpcoes");
            }
        }
        public void Clicar_Midia()
        {
            try
            {
                Thread.Sleep(TimeSpan.FromMilliseconds(500));
                var btn = driver.FindElement(By.XPath("//android.widget.TextView[@text='Mídia, links e docs']"));
                if (btn != null)
                {
                    btn.Click();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + " ClicarMidia");
            }
        }
        public void Selecionar_Conversa_Enviada()
        {
            try
            {
                Thread.Sleep(TimeSpan.FromMilliseconds(500));
                var all_Conversas = driver.FindElementsByXPath("//*[@class='android.view.ViewGroup']");//ele sempre retorna 2 a mais. a primeira mensagem comeca no count 2
                TouchAction touch = new TouchAction(driver);
                bool p = false;
                int count = 0;
                foreach (AndroidElement conversa in all_Conversas)
                {
                    if (count > 1)
                    {
                        if (p == false)
                        {
                            touch.LongPress(conversa).Perform();
                            Thread.Sleep(TimeSpan.FromMilliseconds(500));
                            p = true;
                        }
                        else
                        {
                            conversa.Click();
                        }
                    }
                    count++;
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + " SelecionarConversaEnviada");
            }
        }
        public void Clicar_Compartilhar()
        {
            try
            {
                Thread.Sleep(TimeSpan.FromMilliseconds(500));
                var btn = driver.FindElement(By.XPath("//android.widget.TextView[@resource-id='com.whatsapp.w4b:id/menuitem_forward']"));
                if (btn != null)
                {
                    btn.Click();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + " ClicarCompartilhar");
            }
        }
        public void Clicar_Voltar_Compartilhar_Perfil()
        {
            try
            {
                Thread.Sleep(TimeSpan.FromMilliseconds(500));
                var btn = driver.FindElement(By.XPath("//android.widget.ImageButton[@content-desc='Navegar para cima']"));
                if (btn != null)
                {
                    btn.Click();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + " ClicarVoltar");
            }
        }
        public List<string> Retornar_Conversas()
        {
            List<string> lstResult_noFormat = new List<string>();
            List<string> lstResult = new List<string>();
            
            try
            {
                Thread.Sleep(TimeSpan.FromSeconds(1));
                System.Collections.ObjectModel.ReadOnlyCollection<AndroidElement> all_messages = driver.FindElementsByXPath("//android.widget.TextView[@resource-id='com.whatsapp.w4b:id/message_text']");

                foreach (AndroidElement message in all_messages)
                {
                    lstResult_noFormat.Add(message.Text);

                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + " Retornar_Conversas_Pendentes");
            }
            foreach (string strFormat in lstResult_noFormat)
            {
                StringBuilder sbReturn = new StringBuilder();
                var arrayText = strFormat.Normalize(NormalizationForm.FormD).ToCharArray();
                foreach (char letter in arrayText)
                {
                    if (CharUnicodeInfo.GetUnicodeCategory(letter) != UnicodeCategory.NonSpacingMark)
                        sbReturn.Append(letter);
                }
                lstResult.Add(sbReturn.ToString().ToUpper());
            }
            return lstResult;
        }
        // Funções Completas
        public void Envio_Dentro_Conversa()
        {
            try
            {
                Clicar_Inserir();
                Clicar_Galeria();
                Clicar_Pasta_Pictures();
                Selecionar_Imagens_Pictures();
                Confirmar_Selecao_Imagens_Pictures();
                Clicar_Enviar();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + " EnvioDentroDaConversa");
            }

        }
        public void Compartilhar_Dentro_Conversa()
        {
            try
            {
                Thread.Sleep(TimeSpan.FromSeconds(20));
                Clicar_Opcoes();
                Clicar_Midia();
                Selecionar_Imagens_Pictures();
                Clicar_Compartilhar();
                Clicar_Lupa_Procurar_Contatos();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + " CompartilharDentroDaConversa");
            }

        }
        public void Compartilhar_Dentro_Midia()
        {
            try
            {
                Selecionar_Imagens_Pictures();
                Clicar_Compartilhar();
                Clicar_Lupa_Procurar_Contatos();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + " CompartilharDentroDaConversa");
            }

        }
        #endregion

        #region Backup - Politica e Termos
        public bool VerificarBackup()
        {
            bool retorno = false;
            try
            {
                Thread.Sleep(TimeSpan.FromMilliseconds(500));
                var text = driver.FindElement(By.XPath("//android.widget.TextView[@resource-id='com.whatsapp.w4b:id/settings_gdrive_backup_now_category_title']"));
                if (text != null)
                {
                    retorno = true;
                }
            }
            catch { }

            return retorno;
        }
        public void ClicarNuncaBackup()
        {
            try
            {
                Thread.Sleep(TimeSpan.FromMilliseconds(500));
                var btn = driver.FindElement(By.XPath("//android.widget.RadioButton[@text='Nunca']"));
                if (btn != null)
                {
                    btn.Click();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + " ClicarNuncaBackup");
            }
        }
        public void ClicarOkBackup()
        {
            try
            {
                Thread.Sleep(TimeSpan.FromMilliseconds(500));
                var btn = driver.FindElement(By.XPath("//android.widget.Button[@resource-id='com.whatsapp.w4b:id/gdrive_new_user_setup_btn']"));
                if (btn != null)
                {
                    btn.Click();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + " ClicarOkBackup");
            }
        }
        public void ClicarFecharNotificacao()
        {
            try
            {
                Thread.Sleep(TimeSpan.FromMilliseconds(500));
                var btn = driver.FindElement(By.XPath("//android.widget.ImageView[@resource-id='com.whatsapp.w4b:id/cancel']"));
                if (btn != null)
                {
                    btn.Click();
                }
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.Message + " ClicarFecharNotificacao");
            }
        }

        //Funções Completas
        public void ResolverBackupTermos()
        {
            try
            {
                if (VerificarBackup() == true)
                {
                    ClicarNuncaBackup();
                    ClicarOkBackup();
                }
            }
            catch { }

            try
            {
                ClicarFecharNotificacao();
            }
            catch { }
        }
        #endregion

        #region Deletar Conversa
        public void Clicar_Mais_Opcoes()
        {
            try
            {
                Thread.Sleep(TimeSpan.FromMilliseconds(500));
                var btn = driver.FindElement(By.XPath("//android.widget.ImageView[@content-desc='Mais opções']"));
                if (btn != null)
                {
                    btn.Click();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + " ClicarMaisOpcoes");
            }
        }
        public void Clicar_Selecionar_Todas()
        {
            try
            {
                Thread.Sleep(TimeSpan.FromMilliseconds(500));
                var btn = driver.FindElement(By.XPath("//android.widget.TextView[@text='Selecionar todas']"));
                if (btn != null)
                {
                    btn.Click();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + " ClicarSelecionarTodas");
            }
        }
        public void Clicar_Apagar_Conversas_Lixeira()
        {
            try
            {
                Thread.Sleep(TimeSpan.FromSeconds(1));
                var btn = driver.FindElement(By.XPath("//android.widget.TextView[@resource-id='com.whatsapp.w4b:id/menuitem_conversations_delete']"));
                if (btn != null)
                {
                    btn.Click();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + " ClicarApagarConversas");
            }
        }
        public void Clicar_Confirmar_Apagar()
        {
            try
            {
                Thread.Sleep(TimeSpan.FromMilliseconds(500));
                var btn = driver.FindElement(By.XPath("//android.widget.Button[@resource-id='android:id/button1']"));
                if (btn != null)
                {
                    btn.Click();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + " ClicarApagar");
            }
        }
        //Funções Completas
        public void ApagarConversas()
        {
            int conversas = Total_Conversas();
            if (conversas > 0)
            {
                if (conversas > 1)
                {
                    Clicar_Mais_Opcoes();
                    Clicar_Selecionar_Todas();
                }

                Clicar_Apagar_Conversas_Lixeira();
                Clicar_Confirmar_Apagar();
                Thread.Sleep(TimeSpan.FromSeconds(10));
            }
        }
        #endregion
    }
}
