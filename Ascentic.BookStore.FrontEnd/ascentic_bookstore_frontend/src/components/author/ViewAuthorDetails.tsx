import * as React from 'react';
import { RouteComponentProps, withRouter, Link } from 'react-router-dom';
import axios from 'axios';

import { Layout,Card,Descriptions } from 'antd';
import "antd/dist/antd.css";

const {Content,Sider} = Layout;
const {Meta} = Card;

export interface IValues {
    [key: string]: any;
}
export interface IFormState {
    id: number,
    author: any,
    ratings: any,
    loading: false,
}

class ViewAuthorDetails extends React.Component<RouteComponentProps<any>, IFormState> {
    constructor(props: RouteComponentProps) {
        super(props);
        this.state = {
            id: this.props.match.params.id,
            author: {},
            ratings:{},
            loading: false
        }
    }

    public componentDidMount(): void {
        const config = {
            headers: { Authorization: `Bearer ${localStorage.getItem('AccessToken')}`}
        };
        axios.get(`https://localhost:44359/api/Author/get_full_author_details/${this.state.id}`,config).then(data => {
            this.setState({ author: data.data });
            console.log(this.state);
        }).catch(err=>{
            this.HandleError(err);
          })
    }


    RedirectToLogin() {
        this.props.history.push("/login");
    }
  
      HandleError(err:any){
        if(err.response.status==401){
          this.RedirectToLogin();
        }
        else{
          console.log(err)
        }
      }


    public render() {
        const {  loading,author,ratings } = this.state;
        return (
            <div style={{background: '#fff', padding: 24,marginBottom:20, minHeight: 800 }}>
               <Layout style={{background: '#fff', padding: 24,marginBottom:20, minHeight: 800 }}>
                    <Sider style={{background: '#fff',maxWidth:900}}>
                        <div>
                            <Card
                                cover={<img alt="example" src={author.photoURL?author.photoURL:"/book-cover-placeholder.jpg"} />}
                            >
                           
                            </Card>
                        </div>
                    </Sider>
                    <Content>
                        <div style={{padding: 50}}>
                            <Descriptions title="Book Details">
                                <Descriptions.Item label="Name">{author.name}</Descriptions.Item>
                            <Descriptions.Item label="Books">
                                {author.bookAuthor && author.bookAuthor.map((bookData: any) =>
                                    <Link to={`/book-details/${bookData.book.id}`} key={bookData.book.id}>
                                        <p style={{paddingLeft:5}} >{bookData.book.title}</p>
                                     </Link>
                                )}
                            </Descriptions.Item>
                            <Descriptions.Item label="Birthday">{author.birthDay}
                            </Descriptions.Item>
                            <Descriptions.Item label="BirthPlace">{author.birthPlace}
                            </Descriptions.Item>
                            <Descriptions.Item label="Facts">
                                {author.facts}
                            </Descriptions.Item>
                            </Descriptions>  
                            
                           
                        </div>       
                    </Content>
                </Layout>
           </div>
        )
    }
}
export default withRouter(ViewAuthorDetails)