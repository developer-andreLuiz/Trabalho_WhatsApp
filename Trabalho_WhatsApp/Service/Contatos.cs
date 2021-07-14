using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Interfaces;
using OpenQA.Selenium.Appium.MultiTouch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trabalho_WhatsApp.Service
{
    class Contatos
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
                appOptions.AddAdditionalCapability("appPackage", "com.android.contacts");
                appOptions.AddAdditionalCapability("appActivity", "com.android.contacts.activities.PeopleActivity");
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

        public void Clicar_Pesquisar()
        {
            try
            {
                Thread.Sleep(TimeSpan.FromMilliseconds(500));
                var btn = driver.FindElement(By.XPath("//android.widget.TextView[@content-desc='Pesquisar']"));
                if (btn != null)
                {
                    btn.Click();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + " Clicar_Pesquisar");
            }
        }
      
        public void Digitar_Nome(string nome)
        {
            try
            {
                Thread.Sleep(TimeSpan.FromMilliseconds(500));
                var txtEdit = driver.FindElement(By.XPath("//android.widget.EditText[@resource-id='com.android.contacts:id/search_view']"));
                txtEdit.SendKeys(nome);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + " DigitarMensagem");
            }
        }
        public void Clicar_Contato_Encontrado()
        {
            try
            {
                Thread.Sleep(TimeSpan.FromMilliseconds(700));
                var btn = driver.FindElement(By.XPath("//android.widget.TextView[@resource-id='com.android.contacts:id/cliv_name_textview']"));
                if (btn != null)
                {
                    btn.Click();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + " Clicar_Contato_Encontrado");
            }
        }
        public void Clicar_Opcoes()
        {
            try
            {
                Thread.Sleep(TimeSpan.FromMilliseconds(700));
                var btn = driver.FindElement(By.XPath("//android.widget.ImageButton[@content-desc='Mais opções']"));
                if (btn != null)
                {
                    btn.Click();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + " Clicar_Opcoes");
            }
        }
        public void Clicar_Opcoes_Excluir()
        {
            try
            {
                Thread.Sleep(TimeSpan.FromMilliseconds(500));
                var btn = driver.FindElement(By.XPath("//android.widget.TextView[@text='Excluir']"));
                if (btn != null)
                {
                    btn.Click();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + " Clicar_Opcoes_Excluir");
            }
        }
        public void Clicar_Confirmar_Excluir()
        {
            try
            {
                Thread.Sleep(TimeSpan.FromMilliseconds(700));
                var btn = driver.FindElement(By.XPath("//android.widget.Button[@text='OK']"));
                if (btn != null)
                {
                    btn.Click();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + " Clicar_Confirmar_Excluir");
            }
        }
        public void Clicar_LimparPesquisa()
        {
            try
            {
                Thread.Sleep(TimeSpan.FromMilliseconds(700));
                var btn = driver.FindElement(By.XPath("//android.widget.ImageView[@resource-id='com.android.contacts:id/search_close_button']"));
                if (btn != null)
                {
                    btn.Click();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + " Clicar_LimparPesquisa");
            }
        }
    }
}
