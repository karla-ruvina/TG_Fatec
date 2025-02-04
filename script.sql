USE [TG_fatec]
GO
/****** Object:  Table [dbo].[Avaliacao]    Script Date: 16/11/2022 18:45:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Avaliacao](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdEntrega] [int] NOT NULL,
	[Estrelas] [int] NULL,
	[Comentario] [varchar](500) NULL,
 CONSTRAINT [PK_Avaliacao] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 16/11/2022 18:45:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdUsuario] [int] NOT NULL,
	[AceitaReceberEmails] [bit] NULL,
	[AceitaReceberSMS] [bit] NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Entrega]    Script Date: 16/11/2022 18:45:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Entrega](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdPedido] [int] NOT NULL,
	[Saida] [datetime] NULL,
	[PrevisaoEntrega] [datetime] NULL,
	[Entrega] [datetime] NULL,
	[Distancia] [decimal](18, 0) NULL,
	[ValorEntrega] [decimal](18, 0) NULL,
	[Troco] [bit] NULL,
	[ValorTroco] [decimal](18, 0) NULL,
	[Cartao] [bit] NULL,
 CONSTRAINT [PK_Entrega] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ItensPedido]    Script Date: 16/11/2022 18:45:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ItensPedido](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdProduto] [int] NOT NULL,
	[IdPedido] [int] NOT NULL,
	[DataCadastro] [datetime] NULL,
	[Valor] [decimal](18, 0) NULL,
	[Quantidade] [decimal](18, 0) NULL,
	[Status] [varchar](15) NULL,
 CONSTRAINT [PK_ItensPedido] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pedido]    Script Date: 16/11/2022 18:45:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pedido](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdCliente] [int] NOT NULL,
	[DataPedido] [datetime] NULL,
	[TipoEntrega] [varchar](50) NULL,
	[ValorPedido] [decimal](18, 0) NULL,
	[QuantidadeItens] [decimal](18, 0) NULL,
	[Status] [varchar](15) NULL,
 CONSTRAINT [PK_Pedido] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Produto]    Script Date: 16/11/2022 18:45:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Produto](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](50) NULL,
	[Quantidade] [decimal](18, 0) NULL,
	[Valor] [decimal](18, 0) NULL,
	[Descricao] [varchar](500) NULL,
	[UnidadeMedida] [varchar](50) NULL,
	[Medida] [decimal](18, 0) NULL,
	[Imagem] [varchar](5000) NULL,
	[TipoProduto] [int] NULL,
 CONSTRAINT [PK_Produto] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Produtor]    Script Date: 16/11/2022 18:45:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Produtor](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdUsuario] [int] NOT NULL,
	[AceitaCartao] [bit] NULL,
	[AceitaPix] [bit] NULL,
	[RealizaEntregas] [bit] NULL,
	[EnderecoProducao] [varchar](500) NULL,
	[CertificadoOrganico] [varchar](500) NULL,
 CONSTRAINT [PK_Produtor] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProdutosProdutor]    Script Date: 16/11/2022 18:45:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProdutosProdutor](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdProdutor] [int] NOT NULL,
	[IdProduto] [int] NOT NULL,
	[DataCadastro] [datetime] NULL,
 CONSTRAINT [PK_ProdutosProdutor] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 16/11/2022 18:45:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](250) NULL,
	[CPF] [varchar](50) NULL,
	[DataNascimento] [datetime] NULL,
	[Telefone] [varchar](50) NULL,
	[Email] [varchar](70) NULL,
	[Senha] [varchar](50) NULL,
	[CEP] [varchar](10) NULL,
	[Cidade] [varchar](100) NULL,
	[Estado] [varchar](20) NULL,
	[UF] [varchar](2) NULL,
	[Logradouro] [varchar](500) NULL,
	[Numero] [varchar](10) NULL,
	[Bairro] [varchar](50) NULL,
	[Complemento] [varchar](50) NULL,
	[TipoUsuario] [int] NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Cliente] ON 

INSERT [dbo].[Cliente] ([Id], [IdUsuario], [AceitaReceberEmails], [AceitaReceberSMS]) VALUES (1, 2, 1, 1)
SET IDENTITY_INSERT [dbo].[Cliente] OFF
GO
SET IDENTITY_INSERT [dbo].[ItensPedido] ON 

INSERT [dbo].[ItensPedido] ([Id], [IdProduto], [IdPedido], [DataCadastro], [Valor], [Quantidade], [Status]) VALUES (1, 2, 1, CAST(N'2022-11-08T00:00:00.000' AS DateTime), CAST(20 AS Decimal(18, 0)), CAST(4 AS Decimal(18, 0)), N'Processando')
INSERT [dbo].[ItensPedido] ([Id], [IdProduto], [IdPedido], [DataCadastro], [Valor], [Quantidade], [Status]) VALUES (2, 3, 1, CAST(N'2022-11-08T00:00:00.000' AS DateTime), CAST(9 AS Decimal(18, 0)), CAST(3 AS Decimal(18, 0)), N'Processando')
SET IDENTITY_INSERT [dbo].[ItensPedido] OFF
GO
SET IDENTITY_INSERT [dbo].[Pedido] ON 

INSERT [dbo].[Pedido] ([Id], [IdCliente], [DataPedido], [TipoEntrega], [ValorPedido], [QuantidadeItens], [Status]) VALUES (1, 1, CAST(N'2022-11-08T00:00:00.000' AS DateTime), NULL, CAST(29 AS Decimal(18, 0)), CAST(7 AS Decimal(18, 0)), N'Processando')
SET IDENTITY_INSERT [dbo].[Pedido] OFF
GO
SET IDENTITY_INSERT [dbo].[Produto] ON 

INSERT [dbo].[Produto] ([Id], [Nome], [Quantidade], [Valor], [Descricao], [UnidadeMedida], [Medida], [Imagem], [TipoProduto]) VALUES (1, N'Teste 01', CAST(5 AS Decimal(18, 0)), CAST(10 AS Decimal(18, 0)), N'Teste primeiro produto adicionado no banco de dados', N'KG', NULL, NULL, 2)
INSERT [dbo].[Produto] ([Id], [Nome], [Quantidade], [Valor], [Descricao], [UnidadeMedida], [Medida], [Imagem], [TipoProduto]) VALUES (2, N'Cenoura', CAST(12 AS Decimal(18, 0)), CAST(5 AS Decimal(18, 0)), N'cenoura organica', N'KG', NULL, N'/UploadArquivos/Produtos/cenoura.png', 1)
INSERT [dbo].[Produto] ([Id], [Nome], [Quantidade], [Valor], [Descricao], [UnidadeMedida], [Medida], [Imagem], [TipoProduto]) VALUES (3, N'tomate', CAST(8 AS Decimal(18, 0)), CAST(3 AS Decimal(18, 0)), N'tomate com foto', N'KG', NULL, N'/UploadArquivos/Produtos/tomate.jpg', 2)
INSERT [dbo].[Produto] ([Id], [Nome], [Quantidade], [Valor], [Descricao], [UnidadeMedida], [Medida], [Imagem], [TipoProduto]) VALUES (1003, N'Berinjela', CAST(6 AS Decimal(18, 0)), CAST(4 AS Decimal(18, 0)), N'qualquer coisa de descrição', N'KG', NULL, N'/UploadArquivos/Produtos/berinjela.jpg', 1)
INSERT [dbo].[Produto] ([Id], [Nome], [Quantidade], [Valor], [Descricao], [UnidadeMedida], [Medida], [Imagem], [TipoProduto]) VALUES (1004, N'Mamão', CAST(12 AS Decimal(18, 0)), CAST(8 AS Decimal(18, 0)), N'descricao do mamao', N'UN', NULL, N'/UploadArquivos/Produtos/mamao.jpg', 2)
INSERT [dbo].[Produto] ([Id], [Nome], [Quantidade], [Valor], [Descricao], [UnidadeMedida], [Medida], [Imagem], [TipoProduto]) VALUES (1005, N'banana', CAST(15 AS Decimal(18, 0)), CAST(2 AS Decimal(18, 0)), N'teste', N'KG', NULL, N'/UploadArquivos/Produtos/banana.jpg', 2)
SET IDENTITY_INSERT [dbo].[Produto] OFF
GO
SET IDENTITY_INSERT [dbo].[Produtor] ON 

INSERT [dbo].[Produtor] ([Id], [IdUsuario], [AceitaCartao], [AceitaPix], [RealizaEntregas], [EnderecoProducao], [CertificadoOrganico]) VALUES (1, 1, 1, 1, 1, N'Esse ai', N'ainda nao tem')
INSERT [dbo].[Produtor] ([Id], [IdUsuario], [AceitaCartao], [AceitaPix], [RealizaEntregas], [EnderecoProducao], [CertificadoOrganico]) VALUES (3, 3, 0, 0, 0, NULL, N'nao tem')
INSERT [dbo].[Produtor] ([Id], [IdUsuario], [AceitaCartao], [AceitaPix], [RealizaEntregas], [EnderecoProducao], [CertificadoOrganico]) VALUES (4, 4, 0, 0, 0, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Produtor] OFF
GO
SET IDENTITY_INSERT [dbo].[ProdutosProdutor] ON 

INSERT [dbo].[ProdutosProdutor] ([Id], [IdProdutor], [IdProduto], [DataCadastro]) VALUES (2, 1, 1, CAST(N'2022-11-03T00:00:00.000' AS DateTime))
INSERT [dbo].[ProdutosProdutor] ([Id], [IdProdutor], [IdProduto], [DataCadastro]) VALUES (6, 1, 2, CAST(N'2022-11-07T00:00:00.000' AS DateTime))
INSERT [dbo].[ProdutosProdutor] ([Id], [IdProdutor], [IdProduto], [DataCadastro]) VALUES (7, 1, 3, CAST(N'2022-11-07T00:00:00.000' AS DateTime))
INSERT [dbo].[ProdutosProdutor] ([Id], [IdProdutor], [IdProduto], [DataCadastro]) VALUES (1009, 1, 1003, CAST(N'2022-11-08T00:00:00.000' AS DateTime))
INSERT [dbo].[ProdutosProdutor] ([Id], [IdProdutor], [IdProduto], [DataCadastro]) VALUES (1010, 3, 1004, CAST(N'2022-11-08T20:23:50.343' AS DateTime))
INSERT [dbo].[ProdutosProdutor] ([Id], [IdProdutor], [IdProduto], [DataCadastro]) VALUES (1011, 4, 1005, CAST(N'2022-11-08T20:43:22.600' AS DateTime))
SET IDENTITY_INSERT [dbo].[ProdutosProdutor] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuario] ON 

INSERT [dbo].[Usuario] ([Id], [Nome], [CPF], [DataNascimento], [Telefone], [Email], [Senha], [CEP], [Cidade], [Estado], [UF], [Logradouro], [Numero], [Bairro], [Complemento], [TipoUsuario]) VALUES (1, N'Karla Ruvina Produtor', N'12312312312', CAST(N'2001-02-02T00:00:00.000' AS DateTime), N'43988252547', N'karla.ruvina@produtor.com', N'123', N'86410000', N'Ribeirão Claro', N'PR', N'PR', N'Rua teste', N'123', N'centro', NULL, 1)
INSERT [dbo].[Usuario] ([Id], [Nome], [CPF], [DataNascimento], [Telefone], [Email], [Senha], [CEP], [Cidade], [Estado], [UF], [Logradouro], [Numero], [Bairro], [Complemento], [TipoUsuario]) VALUES (2, N'Karla Ruvina Cliente', N'11111111111', CAST(N'2001-02-02T00:00:00.000' AS DateTime), N'43988225544', N'karla.ruvina@cliente.com', N'123', N'19900000', N'Ourinhos', N'SP', N'SP', N'Rua qualquer uma', N'111', N'centro', NULL, 2)
INSERT [dbo].[Usuario] ([Id], [Nome], [CPF], [DataNascimento], [Telefone], [Email], [Senha], [CEP], [Cidade], [Estado], [UF], [Logradouro], [Numero], [Bairro], [Complemento], [TipoUsuario]) VALUES (3, N'karla produtor 2', N'11.111.111/1111-11', NULL, N'11111111111111', N'karla.ruvina@produtor2.com', N'123', N'86410-000', N'Ribeirão Claro', NULL, N'PR', N'teste', N'centro', NULL, N'a', 1)
INSERT [dbo].[Usuario] ([Id], [Nome], [CPF], [DataNascimento], [Telefone], [Email], [Senha], [CEP], [Cidade], [Estado], [UF], [Logradouro], [Numero], [Bairro], [Complemento], [TipoUsuario]) VALUES (4, N'Elaine', N'11.111.111/1111-11', NULL, N'11111111111111', N'teste@gmail.com', N'123', N'86410-000', N'Ourinhos', NULL, N'SP', N'teste', N'centro', NULL, N'a', 1)
SET IDENTITY_INSERT [dbo].[Usuario] OFF
GO
ALTER TABLE [dbo].[Avaliacao]  WITH CHECK ADD  CONSTRAINT [FK_Avaliacao_Entrega] FOREIGN KEY([IdEntrega])
REFERENCES [dbo].[Entrega] ([Id])
GO
ALTER TABLE [dbo].[Avaliacao] CHECK CONSTRAINT [FK_Avaliacao_Entrega]
GO
ALTER TABLE [dbo].[Cliente]  WITH CHECK ADD  CONSTRAINT [FK_Cliente_Usuario] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuario] ([Id])
GO
ALTER TABLE [dbo].[Cliente] CHECK CONSTRAINT [FK_Cliente_Usuario]
GO
ALTER TABLE [dbo].[Entrega]  WITH CHECK ADD  CONSTRAINT [FK_Entrega_Pedido] FOREIGN KEY([IdPedido])
REFERENCES [dbo].[Pedido] ([Id])
GO
ALTER TABLE [dbo].[Entrega] CHECK CONSTRAINT [FK_Entrega_Pedido]
GO
ALTER TABLE [dbo].[ItensPedido]  WITH CHECK ADD  CONSTRAINT [FK_ItensPedido_Pedido] FOREIGN KEY([IdPedido])
REFERENCES [dbo].[Pedido] ([Id])
GO
ALTER TABLE [dbo].[ItensPedido] CHECK CONSTRAINT [FK_ItensPedido_Pedido]
GO
ALTER TABLE [dbo].[ItensPedido]  WITH CHECK ADD  CONSTRAINT [FK_ItensPedido_Produto] FOREIGN KEY([IdProduto])
REFERENCES [dbo].[Produto] ([Id])
GO
ALTER TABLE [dbo].[ItensPedido] CHECK CONSTRAINT [FK_ItensPedido_Produto]
GO
ALTER TABLE [dbo].[Pedido]  WITH CHECK ADD  CONSTRAINT [FK_Pedido_Cliente] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Cliente] ([Id])
GO
ALTER TABLE [dbo].[Pedido] CHECK CONSTRAINT [FK_Pedido_Cliente]
GO
ALTER TABLE [dbo].[Produtor]  WITH CHECK ADD  CONSTRAINT [FK_Produtor_Usuario] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuario] ([Id])
GO
ALTER TABLE [dbo].[Produtor] CHECK CONSTRAINT [FK_Produtor_Usuario]
GO
ALTER TABLE [dbo].[ProdutosProdutor]  WITH CHECK ADD  CONSTRAINT [FK_ProdutosProdutor_Produto] FOREIGN KEY([IdProduto])
REFERENCES [dbo].[Produto] ([Id])
GO
ALTER TABLE [dbo].[ProdutosProdutor] CHECK CONSTRAINT [FK_ProdutosProdutor_Produto]
GO
ALTER TABLE [dbo].[ProdutosProdutor]  WITH CHECK ADD  CONSTRAINT [FK_ProdutosProdutor_Produtor] FOREIGN KEY([IdProdutor])
REFERENCES [dbo].[Produtor] ([Id])
GO
ALTER TABLE [dbo].[ProdutosProdutor] CHECK CONSTRAINT [FK_ProdutosProdutor_Produtor]
GO
