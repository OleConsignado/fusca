# Fusca
[![Build Status](https://travis-ci.org/OleConsignado/fusca.svg?branch=master)](https://travis-ci.org/OleConsignado/fusca)

**Fusca** é um modelo de arquitetura de software para projetos .NET Core e consiste em uma adaptação simplificada da arquitetura Hexagonal. 

O Fusca foi inicialmente criado para atender uma demanda de construção de fachadas para APIs legadas, onde a presença de regras de negócio é praticamente nula. 

Em relação à arquitetura hexagonal, a principal diferença se dá à ausência da camada de aplicação. A camada de adaptador de entrada, Web API, acumula a responsabilidade da camada de aplicação e o modelo de domínio é o modelo exposto pela Web API, ou seja, os seus DTOs.

## Criando um projeto baseado no Fusca

A forma mais simples de criar um projeto baseado no **Fusca** é por meio do mecanismo de templates do .NET Core.

Para instalar (ou atualizar) o template do **Fusca** na sua máquina (o pacote do template está hospedado no [NuGet.org](https://www.nuget.org/packages/Fusca)), simplesmente execute:

```
$ dotnet new -i fusca
```

Para criar um projeto usando o template **Fusca**, execute:

```
$ dotnet new fusca --name=MeuProjeto
```

Caso deseje desinstalar o template **Fusca**, execute:

```
$ dotnet new -u fusca
```

## Colaborando com o Fusca

*Issues* e *Pull Requests* são bem vindos.
