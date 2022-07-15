using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml;
using System.Xml.Serialization;

namespace EDMX2TSConsole
{
    internal class Program
    {
        public SchemaEntityType mainEntityType = new SchemaEntityType();
        List<string> textList = new List<string>();

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public void Generate()
        {

            var edmx = textBox2.Text;
            if (string.IsNullOrEmpty(edmx))
            {
                MessageBox.Show("You must provide a EDMX text to be converted.", "Warning", MessageBoxButtons.OK);
                return;
            }

            try
            {
                var root = Deserialize<Edmx>(edmx);
                var entityTypes = root.DataServices.Schema.EntityType;
                var selectEntityForm = new Form2();
                selectEntityForm.listBox1.Items.AddRange(entityTypes.Select(x => x.Name).ToArray());
                selectEntityForm.listBox1.SelectedValueChanged += (object senders, EventArgs es) =>
                {
                    mainEntityType = entityTypes.FirstOrDefault(et => et.Name == selectEntityForm.listBox1.Text);
                    selectEntityForm.listBox1.Items.Clear();
                    selectEntityForm.Close();
                };
                selectEntityForm.ShowDialog();

                var entity = GenerateEntity(entityTypes);
                var irepository = GenerateIRepository(mainEntityType);
                var repository = GenerateRepository(entityTypes);
                var service = GenerateService(entityTypes);
                var serviceTest = GenerateServiceTest(entityTypes);
                var repositoryTest = GenerateRepositoryTest(entityTypes);


                var jsonString = JsonSerializer.Serialize(entityTypes);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error on trying to convert the EDMX provided: \r\n {ex.Message}", "Error");
                return;
            }
        }


        public string GenerateRepositoryTest(SchemaEntityType[] entityTypes)
        {
            var name = mainEntityType.Name;
            var filename = tx_filename.Text;

            StringBuilder repositoryTest = new StringBuilder();
            repositoryTest.AppendLine($"/* eslint-disable @typescript-eslint/consistent-type-assertions */");
            repositoryTest.AppendLine($"import {{ HttpService }} from \"@nestjs/axios\";");
            repositoryTest.AppendLine($"import {{ SapHttpService }} from \"@abi/microservices-commons\";");
            repositoryTest.AppendLine($"import {{ Test, TestingModule }} from \"@nestjs/testing\";");
            repositoryTest.AppendLine($"import {{ expect }} from \"chai\";");
            repositoryTest.AppendLine($"import sinon = require(\"sinon\");");
            repositoryTest.AppendLine($"import {{ ODataV2{name}Repository }} from \"../../../../src/automaticassetretirement/adapter/repository/{filename}.repository\";");
            repositoryTest.AppendLine($"import {{ {name}, {name}Id, {string.Join(", ", entityTypes.Where(et => et.Name != name).Select(et => et.Name))} }} from \"../../../../src/automaticassetretirement/domain/entity/{filename}\";");
            repositoryTest.AppendLine($"const {name.FirstCharToLowerCase()}Repository = require(\"../../../../src/automaticassetretirement/adapter/repository/{filename}.repository\");");
            repositoryTest.AppendLine("");

            repositoryTest.AppendLine($"describe(\"{name}Repository\", () => {{");
            repositoryTest.AppendLine("");
            repositoryTest.AppendLine($"\tlet testingModule: TestingModule;");
            repositoryTest.AppendLine($"\tlet repository: ODataV2{name}Repository;");
            repositoryTest.AppendLine("");

            repositoryTest.AppendLine($"\tconst fakeObject = new {name}();");
            foreach (var entityType in entityTypes)
            {
                if (entityType.Name.ToLower() != name.ToLower())
                    repositoryTest.AppendLine($"\tfakeObject.{entityType.Name.FirstCharToLowerCase()} = new {entityType.Name}();");
                foreach (var property in entityType.Property)
                {
                    if (entityType.Name.ToLower() != name.ToLower())
                        repositoryTest.AppendLine($"\tfakeObject.{entityType.Name.FirstCharToLowerCase()}.{property.Name.FirstCharToLowerCase()} = {GetTypeMock(property.Type)};");
                    else
                        repositoryTest.AppendLine($"\tfakeObject.{property.Name.FirstCharToLowerCase()} = {GetTypeMock(property.Type)};");
                }
                repositoryTest.AppendLine("");
            }
            repositoryTest.AppendLine("");

            repositoryTest.AppendLine($"\tconst fakeObjectResult = new {name}();");
            foreach (var entityType in entityTypes)
            {
                bool isMainObject = entityType.Name.ToLower() == name.ToLower();
                if (!isMainObject)
                    repositoryTest.AppendLine($"\tfakeObjectResult.{entityType.Name.FirstCharToLowerCase()} = new {entityType.Name}();");
                foreach (var property in entityType.Property)
                {
                    if (entityType.Name.ToLower() != name.ToLower())
                        repositoryTest.AppendLine($"\tfakeObjectResult.{entityType.Name.FirstCharToLowerCase()}.{property.Name.FirstCharToLowerCase()} = {GetTypeMock(property.Type)};");
                    else
                        repositoryTest.AppendLine($"\tfakeObjectResult.{property.Name.FirstCharToLowerCase()} = {GetTypeMock(property.Type)};");
                }
                if (isMainObject)
                    repositoryTest.AppendLine($"\tfakeObjectResult.setId(new {name}Id({GenerateIdGenerator(entityTypes)}));");
                repositoryTest.AppendLine("");
            }
            repositoryTest.AppendLine("");

            repositoryTest.AppendLine($"\t\tconst fakeViewModel = {{");
            foreach (var entityType in entityTypes)
            {
                bool isMainObject = entityType.Name.ToLower() == name.ToLower();
                if (!isMainObject)
                    repositoryTest.AppendLine($"\t\t{entityType.Name}: {{");
                foreach (var property in entityType.Property)
                {
                    repositoryTest.AppendLine($"\t\t\t{property.Name}: {GetTypeMock(property.Type)},");
                }
                if (!isMainObject)
                    repositoryTest.AppendLine($"\t\t}},");
            }
            repositoryTest.AppendLine($"\t}};");
            repositoryTest.AppendLine("");

            repositoryTest.AppendLine($"\t\tconst fakeViewModelResult = {{");
            foreach (var entityType in entityTypes)
            {
                bool isMainObject = entityType.Name.ToLower() == name.ToLower();
                if (!isMainObject)
                    repositoryTest.AppendLine($"\t\t{entityType.Name}: {{");
                foreach (var property in entityType.Property)
                {
                    repositoryTest.AppendLine($"\t\t{property.Name}: {GetTypeMock(property.Type)},");
                }
                if (!isMainObject)
                    repositoryTest.AppendLine($"\t\t}},");
            }
            repositoryTest.AppendLine($"\t}};");
            repositoryTest.AppendLine("");


            repositoryTest.AppendLine($"\tbeforeEach(async () => {{");
            repositoryTest.AppendLine($"\t\ttestingModule = await Test.createTestingModule({{");
            repositoryTest.AppendLine($"\t\t\tproviders: [");
            repositoryTest.AppendLine($"\t\t\t\tHttpService,");
            repositoryTest.AppendLine($"\t\t\t\tSapHttpService,");
            repositoryTest.AppendLine($"\t\t\t\t{{ provide: \"{name.AddUnderlineSpacerToUpper()}_URL\", useValue: \"any_url\" }},");
            repositoryTest.AppendLine($"\t\t\t\t{{ provide: \"{name.AddUnderlineSpacerToUpper()}_VERSION\", useValue: \"any_version\" }},");
            repositoryTest.AppendLine($"\t\t\t\t{{ provide: \"{name.AddUnderlineSpacerToUpper()}_SAP_CLIENT\", useValue: \"any_sapclient\" }},");
            repositoryTest.AppendLine($"\t\t\t\t{{ provide: \"{name.AddUnderlineSpacerToUpper()}_SUBSCRIPTION_KEY\", useValue: \"any_key\" }},");
            repositoryTest.AppendLine($"\t\t\t\t{{ provide: \"{name.AddUnderlineSpacerToUpper()}_ODataToken\", useValue: \"any_token\" }},");
            repositoryTest.AppendLine($"\t\t\t\t{{ provide: \"AXIOS_INSTANCE_TOKEN\", useValue: \"any_axios_instance_token\" }},");
            repositoryTest.AppendLine($"\t\t\t\t{{ provide: \"{name}Repository\", useValue: {name.FirstCharToLowerCase()}Repository.ODataV2{name}Repository }},");
            repositoryTest.AppendLine($"\t\t\t\tODataV2{name}Repository,");
            repositoryTest.AppendLine($"\t\t\t],");
            repositoryTest.AppendLine($"\t\t}}).compile();");
            repositoryTest.AppendLine($"");
            repositoryTest.AppendLine($"\t\trepository = testingModule.get<ODataV2{name}Repository>(ODataV2{name}Repository);");
            repositoryTest.AppendLine($"\t}});");
            repositoryTest.AppendLine($"");

            repositoryTest.AppendLine($"\tafter(async () => await testingModule.close());");
            repositoryTest.AppendLine($"");

            repositoryTest.AppendLine($"\tdescribe(\"shouldUpdate\", () => {{");
            repositoryTest.AppendLine($"");
            repositoryTest.AppendLine($"\t\tit(\"Should return false when parameter is not {name}\", () => {{");
            repositoryTest.AppendLine($"\t\t\tconst shouldUpdate = repository.shouldUpdate(fakeObject);");
            repositoryTest.AppendLine($"\t\t\texpect(shouldUpdate).to.be.false;");
            repositoryTest.AppendLine($"\t\t}});");
            repositoryTest.AppendLine($"");
            repositoryTest.AppendLine($"\t}});");
            repositoryTest.AppendLine($"");

            repositoryTest.AppendLine($"\tdescribe(\"mapToEntity\", () => {{");
            repositoryTest.AppendLine($"");
            repositoryTest.AppendLine($"\t\tit(\"Should return entity when receive valid model as parameter\", () => {{");
            repositoryTest.AppendLine($"\t\t\tconst parseOdataId = sinon.stub(repository, <any>\"parseOdataId\");");
            repositoryTest.AppendLine($"\t\t\tparseOdataId.returns(\"\");");
            repositoryTest.AppendLine($"");
            repositoryTest.AppendLine($"\t\t\tconst mapToEntity = repository.mapToEntity(fakeViewModelResult);");
            repositoryTest.AppendLine($"\t\t\texpect(mapToEntity).to.be.deep.eq(fakeObjectResult);");
            repositoryTest.AppendLine($"\t\t}});");
            repositoryTest.AppendLine($"");
            repositoryTest.AppendLine($"\t}});");
            repositoryTest.AppendLine($"");

            repositoryTest.AppendLine($"\tdescribe(\"mapToOdata\", () => {{");
            repositoryTest.AppendLine($"");
            repositoryTest.AppendLine($"\t\tit(\"Should map to OData format\", () => {{");
            repositoryTest.AppendLine($"\t\t\tconst mapToOdata = repository.mapToOdata(fakeObject);");
            repositoryTest.AppendLine($"\t\t\texpect(mapToOdata).to.be.deep.eq(fakeViewModel);");
            repositoryTest.AppendLine($"\t\t}});");
            repositoryTest.AppendLine($"");
            repositoryTest.AppendLine($"\t}});");
            repositoryTest.AppendLine($"");

            repositoryTest.AppendLine($"\tdescribe(\"generateOdataId\", () => {{");
            repositoryTest.AppendLine($"");
            repositoryTest.AppendLine($"\t\tit(\"Should return empty string\", () => {{");
            repositoryTest.AppendLine($"");
            repositoryTest.AppendLine($"\t\t\tconst {name.FirstCharToLowerCase()}Id = new {name}Id({GenerateIdGenerator(entityTypes)});");
            repositoryTest.AppendLine($"\t\t\tconst mapToOdata = repository.generateOdataId({name.FirstCharToLowerCase()}Id);");
            repositoryTest.AppendLine($"\t\t\texpect(mapToOdata).to.be.deep.eq(`(Compcode='1',AssetClass='1',FamilyGroup='1',AssetNumber='1')`);");
            repositoryTest.AppendLine($"\t\t}});");
            repositoryTest.AppendLine($"");
            repositoryTest.AppendLine($"\t}});");
            repositoryTest.AppendLine($"");

            repositoryTest.AppendLine($"}});");
            repositoryTest.AppendLine("");


            return repositoryTest.ToString();
        }

        public string GenerateServiceTest(SchemaEntityType[] entityTypes)
        {
            var name = mainEntityType.Name;
            var filename = tx_filename.Text;

            StringBuilder service = new StringBuilder();
            service.AppendLine($"import {{ Test, TestingModule }} from \"@nestjs/testing\";");
            service.AppendLine($"import {{ expect }} from \"chai\";");
            service.AppendLine($"import sinon = require(\"sinon\");");
            service.AppendLine($"import {{ SapHttpService }} from \"@abi/microservices-commons\";");
            service.AppendLine($"import {{ HttpService }} from '@nestjs/common';");
            service.AppendLine($"import {{ Optional }} from \"@abi/microservices-commons\";");
            service.AppendLine($"import {{ {name}Service }} from '../../../../src/automaticassetretirement/domain/service/{filename}.service';");
            service.AppendLine($"import {{ {name}, {name}Id, {string.Join(", ", entityTypes.Where(et => et.Name != name).Select(et => et.Name))} }} from \"../../../../src/automaticassetretirement/domain/entity/{filename}\";");
            service.AppendLine($"import {{ {name}Repository }} from '../../../../src/automaticassetretirement/domain/repository/{filename}.repository';");
            service.AppendLine($"import {{ ODataV2{name}Repository }} from \"../../../../src/automaticassetretirement/adapter/repository/{filename}.repository\";");
            service.AppendLine("");

            service.AppendLine($"describe(\"{name}Service\", () => {{");
            service.AppendLine("");
            service.AppendLine($"\tlet service: {name}Service;");
            service.AppendLine($"\tlet module: TestingModule;");
            service.AppendLine($"\tconst currentDate = new Date();");
            service.AppendLine("");

            service.AppendLine($"\tconst mockRepository: {name}Repository = {{");
            service.AppendLine($"\t\tgetById: () => null,");
            service.AppendLine($"\t\tgetAll: () => null,");
            service.AppendLine($"\t\tremove: () => null,");
            service.AppendLine($"\t\tsave: () => null,");
            service.AppendLine($"\t}};");
            service.AppendLine($"");

            service.AppendLine($"\tconst {name.FirstCharToLowerCase()} = new {name}();");
            foreach (var entityType in entityTypes)
            {
                bool isMainObject = entityType.Name.ToLower() == name.ToLower();
                if (!isMainObject)
                    service.AppendLine($"\t{name.FirstCharToLowerCase()}.{entityType.Name.FirstCharToLowerCase()} = new {entityType.Name}();");
                foreach (var property in entityType.Property)
                {
                    if (entityType.Name.ToLower() != name.ToLower())
                        service.AppendLine($"\t{name.FirstCharToLowerCase()}.{entityType.Name.FirstCharToLowerCase()}.{property.Name.FirstCharToLowerCase()} = {GetTypeMock(property.Type)};");
                    else
                        service.AppendLine($"\t{name.FirstCharToLowerCase()}.{property.Name.FirstCharToLowerCase()} = {GetTypeMock(property.Type)};");
                }

                service.AppendLine("");
            }
            service.AppendLine("");

            service.AppendLine($"\tbeforeEach(async () => {{");
            service.AppendLine($"\t\tmodule = await Test.createTestingModule({{");
            service.AppendLine($"\t\t\tproviders: [");
            service.AppendLine($"\t\t\t\tHttpService,");
            service.AppendLine($"\t\t\t\tSapHttpService,");
            service.AppendLine($"\t\t\t\t{{ provide: \"{name.AddUnderlineSpacerToUpper()}_URL\", useValue: \"any_url\" }},");
            service.AppendLine($"\t\t\t\t{{ provide: \"{name.AddUnderlineSpacerToUpper()}_VERSION\", useValue: \"any_version\" }},");
            service.AppendLine($"\t\t\t\t{{ provide: \"{name.AddUnderlineSpacerToUpper()}_SAP_CLIENT\", useValue: \"any_sapclient\" }},");
            service.AppendLine($"\t\t\t\t{{ provide: \"{name.AddUnderlineSpacerToUpper()}_SUBSCRIPTION_KEY\", useValue: \"any_key\" }},");
            service.AppendLine($"\t\t\t\t{{ provide: \"{name.AddUnderlineSpacerToUpper()}_ODataToken\", useValue: \"any_token\" }},");
            service.AppendLine($"\t\t\t\t{{ provide: \"AXIOS_INSTANCE_TOKEN\", useValue: \"any_axios_instance_token\" }},");
            service.AppendLine($"\t\t\t\tODataV2{name}Repository,");
            service.AppendLine($"\t\t\t\t{name}Service,");
            service.AppendLine($"\t\t\t\t{{");
            service.AppendLine($"\t\t\t\t\tprovide: SapHttpService,");
            service.AppendLine($"\t\t\t\t\tuseValue: {{");
            service.AppendLine($"\t\t\t\t\t\tget: () => null,");
            service.AppendLine($"\t\t\t\t\t\tpost: () => null,");
            service.AppendLine($"\t\t\t\t\t\thead: () => null,");
            service.AppendLine($"\t\t\t\t\t}}");
            service.AppendLine($"\t\t\t\t}},");
            service.AppendLine($"\t\t\t\t{{");
            service.AppendLine($"\t\t\t\t\tprovide: \"{name}Repository\",");
            service.AppendLine($"\t\t\t\t\tuseFactory: () => mockRepository");
            service.AppendLine($"\t\t\t\t}}");
            service.AppendLine($"\t\t\t],");
            service.AppendLine($"\t\t}}).compile();");
            service.AppendLine($"");
            service.AppendLine($"\t\tservice = module.get<{name}Service>({name}Service);");
            service.AppendLine($"\t}});");
            service.AppendLine($"");

            service.AppendLine($"\tafter(async () => await module.close());");

            service.AppendLine($"\tdescribe(\"get{name}\", function () {{");
            service.AppendLine($"");
            service.AppendLine($"\t\tit(\"Should return a {name}\", async function () {{");
            service.AppendLine($"\t\t\tconst getById = sinon.stub(mockRepository, \"getById\");");
            service.AppendLine($"\t\t\tconst saved{name} = new {name}();");
            service.AppendLine($"\t\t\tgetById.resolves(Optional.of(saved{name}));");
            service.AppendLine($"");
            service.AppendLine($"\t\t\tconst {name.FirstCharToLowerCase()}Id = new {name}Id({GenerateIdGenerator(entityTypes)});");
            service.AppendLine($"\t\t\tconst opt = await service.getById({name.FirstCharToLowerCase()}Id);");
            service.AppendLine($"");
            service.AppendLine($"\t\t\texpect(opt.isPresent()).to.equal(true);");
            service.AppendLine($"\t\t\tconst result = opt.get();");
            service.AppendLine($"\t\t\texpect(result).to.equal(saved{name});");
            service.AppendLine($"");
            service.AppendLine($"\t\t\tsinon.assert.calledOnce(getById);");
            service.AppendLine($"");
            service.AppendLine($"\t\t\tgetById.restore();");
            service.AppendLine($"\t\t}});");
            service.AppendLine($"\t}});");
            service.AppendLine($"");


            service.AppendLine($"\tdescribe(\"create{name}\", function () {{");
            service.AppendLine($"");
            service.AppendLine($"\t\tit(\"Should create a new {name}\", async function () {{");
            service.AppendLine($"\t\t\tconst save = sinon.stub(mockRepository, \"save\");");
            service.AppendLine($"\t\t\tconst saved{name} = new {name}();");
            service.AppendLine($"\t\t\tsave.resolves(Optional.of(saved{name}));");
            service.AppendLine($"");
            service.AppendLine($"\t\t\tconst toSave = new {name}();");
            service.AppendLine($"");
            service.AppendLine($"\t\t\tconst opt = await service.save(toSave);");
            service.AppendLine($"");
            service.AppendLine($"\t\t\texpect(opt.isPresent()).to.equal(true);");
            service.AppendLine($"\t\t\tconst {name.FirstCharToLowerCase()} = opt.get();");
            service.AppendLine($"\t\t\texpect({name.FirstCharToLowerCase()}).to.equal(saved{name});");
            service.AppendLine($"");
            service.AppendLine($"\t\t\tsinon.assert.calledOnce(save);");
            service.AppendLine($"");
            service.AppendLine($"\t\t\tsave.restore();");
            service.AppendLine($"\t\t}});");

            service.AppendLine($"\t}});");
            service.AppendLine($"}})");
            service.AppendLine("");


            return service.ToString();
        }

        public string GenerateService(SchemaEntityType[] entityTypes)
        {
            var name = mainEntityType.Name;
            var filename = tx_filename.Text;

            StringBuilder service = new StringBuilder();
            service.AppendLine("import { Injectable, Inject } from \"@nestjs/common\";");
            service.AppendLine($"import {{ {name}, {name}Id }} from '../entity/{filename}';");
            service.AppendLine($"import {{ {name}Repository }} from '../repository/{filename}.repository';");
            service.AppendLine("");

            service.AppendLine("@Injectable()");
            service.AppendLine($"export class {name}Service {{");
            service.AppendLine("");

            service.AppendLine($"constructor(@Inject(\"{name}Repository\") private readonly {name.FirstCharToLowerCase()}Repository: {name}Repository) {{ }}");
            service.AppendLine($"");

            service.AppendLine($"\tasync getById({name.FirstCharToLowerCase()}Id: {name}Id): Promise<any> {{");
            service.AppendLine($"\t\treturn await this.{name.FirstCharToLowerCase()}Repository.getById({name.FirstCharToLowerCase()}Id);");
            service.AppendLine($"\t}}");
            service.AppendLine("");

            service.AppendLine($"\tasync save({name.FirstCharToLowerCase()}: {name}): Promise<any> {{");
            service.AppendLine($"\t\tconst existing{name.FirstCharToLowerCase()} = await this.{name.FirstCharToLowerCase()}Repository.getById(this.makeId({name.FirstCharToLowerCase()}));");
            service.AppendLine($"\t\tif (!existing{name.FirstCharToLowerCase()} || !existing{name.FirstCharToLowerCase()}.isPresent()) {{");
            service.AppendLine($"\t\t\treturn await this.{name.FirstCharToLowerCase()}Repository.save({name.FirstCharToLowerCase()});");
            service.AppendLine($"\t\t}} else {{");
            service.AppendLine($"\t\t\treturn null;");
            service.AppendLine($"\t\t}}");
            service.AppendLine($"\t}}");
            service.AppendLine($"");

            service.AppendLine($"\tprivate makeId({name.FirstCharToLowerCase()}: {name}): {name}Id {{");
            service.AppendLine($"\t\treturn new {name}Id(");
            service.AppendLine($"\t\tTODO");
            service.AppendLine($"\t\t);");
            service.AppendLine($"\t}}");



            service.AppendLine($"}}");
            service.AppendLine("");


            return service.ToString();
        }

        public string GenerateRepository(SchemaEntityType[] entityTypes)
        {
            var name = mainEntityType.Name;
            var filename = tx_filename.Text;

            StringBuilder repository = new StringBuilder();
            repository.AppendLine("import { Injectable, Inject } from \"@nestjs/common\";");
            repository.AppendLine("import { CsrfModifier, HttpMethodEnum, ODataV2Repository, SapHttpService } from \"@abi/microservices-commons\";");
            repository.AppendLine($"import {{ {name}, {name}Id, {string.Join(", ", entityTypes.Where(et => et.Name != name).Select(et => et.Name))} }} from '../../../../src/automaticassetretirement/domain/entity/{filename}';");
            repository.AppendLine($"import {{ {name}Repository }} from 'src/automaticassetretirement/domain/repository/{filename}.repository';");
            repository.AppendLine("");

            repository.AppendLine($"class Saved{name} extends {name} {{ }}");

            repository.AppendLine("@Injectable()");
            repository.AppendLine($"export class ODataV2{name}Repository extends ODataV2Repository<{name}Id, {name}> implements {name}Repository {{");
            repository.AppendLine("");

            repository.AppendLine($"\tconstructor(");
            repository.AppendLine($"\thttpService: SapHttpService,");
            repository.AppendLine($"\t@Inject(\"{name.AddUnderlineSpacerToUpper()}_URL\") url: string,");
            repository.AppendLine($"\t@Inject(\"{name.AddUnderlineSpacerToUpper()}_VERSION\") version: string,");
            repository.AppendLine($"\t@Inject(\"{name.AddUnderlineSpacerToUpper()}_SAP_CLIENT\") sapClient: string,");
            repository.AppendLine($"\t@Inject(\"{name.AddUnderlineSpacerToUpper()}_SUBSCRIPTION_KEY\") subscriptionKey: string,");
            repository.AppendLine($"\t@Inject(\"{name.AddUnderlineSpacerToUpper()}_ODataToken\") odataToken: string,");
            repository.AppendLine($"\t) {{");
            repository.AppendLine("");

            repository.AppendLine($"\t\tconst csrfUrl = `api-v-q=${{version}}&subscription-key=${{subscriptionKey}}&sap-client=${{sapClient}}`;");
            repository.AppendLine($"\tsuper(url, httpService, `api-v-q=${{version}}&subscription-key=${{subscriptionKey}}&sap-client=${{sapClient}}`, null, [new CsrfModifier(csrfUrl, HttpMethodEnum.GET)]);");
            repository.AppendLine($"\t}}");
            repository.AppendLine("");

            repository.AppendLine($"\tshouldUpdate(entity: {name}): boolean {{");
            repository.AppendLine($"\t\treturn (entity instanceof Saved{name});");
            repository.AppendLine($"\t}}");
            repository.AppendLine("");

            repository.AppendLine($"\tmapToEntity(model: Record<string, any>): any {{");
            repository.AppendLine($"\t\tconst {name.FirstCharToLowerCase()} = new Saved{name}();");
            repository.AppendLine("");

            foreach (var entityType in entityTypes)
            {
                if (entityType.Name.ToLower() != name.ToLower())
                    repository.AppendLine($"\t\t{name.FirstCharToLowerCase()}.{entityType.Name.FirstCharToLowerCase()} = new {entityType.Name}();");
                foreach (var property in entityType.Property)
                {
                    if (entityType.Name.ToLower() != name.ToLower())
                        repository.AppendLine($"\t\t{name.FirstCharToLowerCase()}.{entityType.Name.FirstCharToLowerCase()}.{(property.Name.FirstCharToLowerCase() == "id" ? "__id" : property.Name.FirstCharToLowerCase())} = model.{entityType.Name}.{property.Name};");
                    else
                        repository.AppendLine($"\t\t{name.FirstCharToLowerCase()}.{(property.Name.FirstCharToLowerCase() == "id" ? "__id" : property.Name.FirstCharToLowerCase())} = model.{property.Name};");
                }
                repository.AppendLine("");
            }
            repository.AppendLine($"\t\tconst id = new {name}Id({GenerateIdGenerator(entityTypes)});");
            repository.AppendLine($"\t\t{name.FirstCharToLowerCase()}.setId(id);");

            repository.AppendLine($"\t\treturn {name.FirstCharToLowerCase()};");
            repository.AppendLine($"\t}}");
            repository.AppendLine("");

            repository.AppendLine($"\tmapToOdata(model: {name}): any {{");
            repository.AppendLine($"\t\tconst {name.FirstCharToLowerCase()}: any ={{}};");

            foreach (var entityType in entityTypes)
            {
                if (entityType.Name.ToLower() != name.ToLower())
                    repository.AppendLine($"\t\t{name.FirstCharToLowerCase()}.{entityType.Name} = {{");

                foreach (var property in entityType.Property)
                {
                    if (entityType.Name.ToLower() != name.ToLower())
                        repository.AppendLine($"\t\t\t{property.Name}: model.{entityType.Name.FirstCharToLowerCase()}.{(property.Name.FirstCharToLowerCase() == "id" ? "__id" : property.Name.FirstCharToLowerCase())},");
                    else
                        repository.AppendLine($"\t\t{name.FirstCharToLowerCase()}.{property.Name} = model.{(property.Name.FirstCharToLowerCase() == "id" ? "__id" : property.Name.FirstCharToLowerCase())};");
                }

                if (entityType.Name.ToLower() != name.ToLower())
                    repository.AppendLine($"\t\t}}");
                repository.AppendLine("");
            }

            repository.AppendLine($"\t\treturn {name.FirstCharToLowerCase()};");
            repository.AppendLine($"\t}}");
            repository.AppendLine("");


            repository.AppendLine($"\tgenerateOdataId(id: {name}Id): string {{");
            repository.AppendLine($"\t\treturn {GenerateIdGeneratorToString(entityTypes, "id")};");
            repository.AppendLine($"\t}}");
            repository.AppendLine("");


            repository.AppendLine($"}}");

            return repository.ToString();
        }

        public string GenerateIRepository(SchemaEntityType entityType)
        {
            var name = mainEntityType.Name;
            var filename = tx_filename.Text;

            StringBuilder iRepository = new StringBuilder();
            iRepository.AppendLine("import { Repository } from \"@abi/microservices-commons\";");
            iRepository.AppendLine($"import {{ {name}, {name}Id }} from '../entity/{filename}';");
            iRepository.AppendLine("");

            iRepository.AppendLine($"export interface {name}Repository extends Repository<{name}Id, {name}> {{");
            iRepository.AppendLine($"}}");

            return iRepository.ToString();
        }

        public string GenerateEntity(SchemaEntityType[] entityTypes)
        {

            StringBuilder entity = new StringBuilder();
            entity.AppendLine("import { Entity } from \"@abi/microservices-commons\";");
            entity.AppendLine("");

            foreach (var entityType in entityTypes)
            {
                var name = entityType.Name;

                entity.AppendLine($"export class {name}Id {{");
                entity.AppendLine($"\tconstructor(");
                if (entityType.Key != null)
                {
                    foreach (var key in entityType.Key)
                    {
                        entity.AppendLine($"\t\tpublic {key.Name}: String,");
                    }
                }
                entity.AppendLine($"\t){{}}");
                entity.AppendLine($"}}");


                entity.AppendLine($"export class {name} extends Entity<{name}Id> {{");
                entity.AppendLine($"\tconstructor() {{");
                entity.AppendLine($"\t\tsuper();");
                entity.AppendLine($"\t}}");
                if (entityType.Property != null)
                {
                    foreach (var property in entityType.Property)
                    {
                        entity.AppendLine($"\t{property.Name.FirstCharToLowerCase()}: {GetTypeStr(property.Type)};");
                    }
                }

                if (entityType.NavigationProperty != null)
                {
                    foreach (var navigationProperty in entityType.NavigationProperty)
                    {
                        entity.AppendLine($"\t{GetNameFromRole(navigationProperty.Name, navigationProperty.FromRole).FirstCharToLowerCase()}: {GetNameFromRole(navigationProperty.Name, navigationProperty.FromRole).FirstCharToUpperCase()};");
                    }
                }
                entity.AppendLine($"}}");
                entity.AppendLine("");
            }


            return entity.ToString();
        }

        public string GenerateIdGeneratorToString(SchemaEntityType[] entityTypes, string objName)
        {
            var mainObject = entityTypes.Where(e => e.Name == mainEntityType.Name).FirstOrDefault();
            if (mainObject == null)
                return "";

            return $"`({string.Join(",", mainObject.Property.Select(e => $"{e.Name}='${{{objName}.{e.Name}}}'"))})`";
        }

        public string GenerateIdGenerator(SchemaEntityType[] entityTypes)
        {
            var mainObject = entityTypes.Where(e => e.Name == mainEntityType.Name).FirstOrDefault();
            if (mainObject == null)
                return "";

            return string.Join(",", mainObject.Property.Select(e => $"{mainObject.Name.FirstCharToLowerCase()}.{e.Name.FirstCharToLowerCase()}"));
        }

        public string GetTypeStr(string type)
        {
            if (type == null)
            {
                return null;
            }

            type = type.Replace("Edm.", "");
            switch (type.ToLower())
            {
                case "string":
                    return "String";
                case "boolean":
                    return "boolean";
                case "DateTime":
                    return "Date";
                case "int":
                    return "number";
                case "decimal":
                    return "number";
                default:
                    return "String";
            }
        }

        public string GetTypeMock(string type)
        {
            if (type == null)
            {
                return "null";
            }

            type = type.Replace("Edm.", "");
            switch (type.ToLower())
            {
                case "string":
                    return "\"String\"";
                case "boolean":
                    return "false";
                case "DateTime":
                    return "currentDate";
                case "int":
                    return "1000";
                case "decimal":
                    return "5000";
                default:
                    return "\"String\"";
            }
        }

        public string GetNameFromRole(string name, string role)
        {
            if (string.IsNullOrEmpty(role) && string.IsNullOrEmpty(name))
                return name;

            var nameIndex = role.ToLower().IndexOf(name.ToLower());
            if (nameIndex == -1)
                return name;

            return role.Substring(nameIndex, name.Length);
        }

        public static T Deserialize<T>(string xmlString)
        {
            if (xmlString == null) return default;
            var serializer = new XmlSerializer(typeof(T));
            using (var reader = new StringReader(xmlString))
            {
                return (T)serializer.Deserialize(reader);
            }
        }
    }

    public static class StringExtensions
    {
        public static string FirstCharToLowerCase(this string str)
        {
            if (string.IsNullOrEmpty(str) || char.IsLower(str[0]))
                return str;

            return char.ToLower(str[0]) + str.Substring(1);
        }

        public static string FirstCharToUpperCase(this string str)
        {
            if (string.IsNullOrEmpty(str) || char.IsUpper(str[0]))
                return str;

            return char.ToUpper(str[0]) + str.Substring(1);
        }


        public static string AddUnderlineSpacerToUpper(this string str)
        {
            StringBuilder result = new StringBuilder();
            result.Append(str[0]);
            if (string.IsNullOrEmpty(str))
                return str;
            for (int i = 1; i < str.Length; i++)
            {
                if (str[i] == str.ToUpper()[i])
                {
                    result.Append($"_{str[i]}");
                }
                else
                {
                    result.Append(str[i]);
                }
            }
            return result.ToString().ToUpper();
        }
    }
}