using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoAspNetMVC03.Data.Interfaces;
using ProjetoAspNetMVC03.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoAspNetMVC03.Controllers
{
    [Authorize]//Somente usuáarios autenticados
    public class UsuarioController : Controller
    {
        //atributo
        private readonly IUsuarioRepository _usuarioRepository;

        //construtor para o AspNet inicializar o atributo
        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public IActionResult MeusDados()
        {
            try
            {
                //obter o email do usuario que esta autenticado no sistema
                var email = User.Identity.Name;
                //acessar o banco de dados para obter os dados do usuário
                var usuario = _usuarioRepository.Obter(email);

                //exibir os dados na página
                TempData["IdUsuario"] = usuario.IdUsuario;
                TempData["Nome"] = usuario.Nome;
                TempData["Email"] = usuario.Email;
                TempData["DataCadastro"] = usuario.DataCadastro.ToString("dd/MM/yyyy");

            }
            catch (Exception e)
            {

                TempData["Mensagem"] = e.Message;
            }
            return View();
        }
        public IActionResult EditarSenha()
        {
           return View();
        }
        [HttpPost]
        public IActionResult EditarSenha(UsuarioEditarSenhaModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //obter o email do usuario autenticado
                    var email = User.Identity.Name;
                    //obter os dados do usuário autenticado
                    var usuario = _usuarioRepository.Obter(email);

                    //verificar se a senha atual informada esta correta
                    if (_usuarioRepository.Obter(usuario.Email, model.SenhaAtual) != null)
                    {
                        //atualizar a senha
                        _usuarioRepository.Alterar(usuario.IdUsuario, model.NovaSenha);
                        TempData["Mensagem"] = "Nova senha atualizada com sucesso. Saia e entre no sistema para testar sua nova senha.";
                    }
                    else
                    {
                        TempData["Mensagem"] = "Sua senha atual está incorreta, por favor entre novamente.";
                    }

                }
                catch (Exception e)
                {
                    TempData["Mensagem"] = e.Message;
                }

            }
            return View();
        }
    }
}
