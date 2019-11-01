import React, {Component} from 'react';
import {Text, View} from 'react-native';
import {FlatList, ScrollView} from 'react-native-gesture-handler';
import { Colors } from 'react-native/Libraries/NewAppScreen';

class App extends Component{
  constructor() {
    super();
    this.state = {
      medicos: [],
      especialidades: [],
    };
  }
  componentDidMount() {
    this._buscarListaEspecialidades();
    this._buscarListaMedicos();
  }

  _converterData(data){
    data = String(data).split('T');
    var dias = String(data[0]).split('-');
    return [ parseInt(dias[2]), "/",parseInt(dias[1]),"/",parseInt(dias[0])]
  }

  _buscarListaMedicos = async () => {
    await fetch('http://192.168.3.201:5000/api/medicos')
      .then(resposta => resposta.json())
      .then(data => this.setState({medicos: data})) 
      .catch(erro => console.warn(erro));
  };
  _buscarListaEspecialidades = async () => {
    await fetch('http://192.168.3.201:5000/api/especialidades')
      .then(resposta => resposta.json())
      .then(data => this.setState({especialidades: data})) 
      .catch(erro => console.warn(erro));
  };

  render() {
    return (
      <View>
        <ScrollView>

        <Text>
          Lista de médicos
        </Text>
      <FlatList
        data={this.state.medicos}
        keyExtractor={item => item.idMedico}
        renderItem={({item}) => (
          <View>
            <Text>{item.nome}</Text>
            <Text>{this._converterData(item.dataDeNascimento)}</Text>
            <Text>{item.crm}</Text>
            <Text>{item.especialidade}</Text>
            <Text>{item.ativo}</Text>
          </View>
        )}
        /><View>
          <Text>
            Lista de especialidades
          </Text>
          <FlatList
          data={this.state.especialidades}
          keyExtractor={item => item.idEspecialidade}
          renderItem={({item}) => (
            <View>
              <Text className="especialidadeLista">{item.especialidade}</Text>

            </View>
          )}
          
          
          
          />

        </View>
          </ScrollView>
        </View>
    );
  }
}






export default App;
